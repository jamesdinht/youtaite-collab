using System;
using System.Collections.Generic;
using Collab.API.Controllers;
using Collab.API.DAL;
using Collab.API.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Collab.API.Tests.Controllers
{
    public class GroupsControllerTest : IDisposable
    {
        private Group fakeGroup;
        private Mock<IRepository<Group>> mockRepo;
        private GroupsController controller;

        public GroupsControllerTest()
        {
            fakeGroup = new Group() { Id = 1, Name = "Preemptive" };
            mockRepo = new Mock<IRepository<Group>>();
        }

        public void Dispose()
        {
            fakeGroup = null;
            mockRepo = null;
            controller = null;
        }

        [Fact]
        public void Get_AllGroups_ShouldReturnEnumerableOfGroups()
         {
            var fakeGroups = new List<Group> { fakeGroup };
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(fakeGroups);
            controller = new GroupsController(mockRepo.Object);

            IActionResult actionResult = controller.Get().Result;
            
            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;

            IEnumerable<Group> groups = result.Value as IEnumerable<Group>;
            var enumerator = groups.GetEnumerator();
            enumerator.MoveNext();

            Assert.NotNull(groups);
            Assert.Equal(fakeGroup.Id, enumerator.Current.Id);
        }

        [Fact]
        public void Get_ByValidId_ShouldReturnAGroup()
        {
            mockRepo.Setup(repo => repo.GetByIdAsync(fakeGroup.Id)).ReturnsAsync(fakeGroup);
            controller = new GroupsController(mockRepo.Object);

            IActionResult actionResult = controller.Get(fakeGroup.Id).Result;

            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;
            Group groupResult = result.Value as Group;

            Assert.NotNull(groupResult);
            Assert.Equal(fakeGroup.Id, groupResult.Id);
        }

        [Fact]
        public void Get_ByInvalidId_ShouldReturnNotFound()
        {
            controller = new GroupsController(mockRepo.Object);

            IActionResult actionResult = controller.Get(1234).Result;

            Assert.NotNull(actionResult);

            NotFoundResult result = actionResult as NotFoundResult;
            
            Assert.NotNull(result);
        }

        [Fact]
        public void Create_ValidGroup_ShouldReturnCreatedAt()
        {
            controller = new GroupsController(mockRepo.Object);

            IActionResult actionResult = controller.Post(fakeGroup).Result;

            Assert.NotNull(actionResult);

            CreatedAtActionResult result = actionResult as CreatedAtActionResult;
            var routeValues = result.RouteValues;

            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(fakeGroup.Id, routeValues["Id"]);
            mockRepo.Verify(repo => repo.CreateAsync(fakeGroup));
        }

        [Fact]
        public void Update_ValidId_ShouldReturnNoContent()
        {
            mockRepo.Setup(repo => repo.GetByIdAsync(fakeGroup.Id)).ReturnsAsync(fakeGroup);
            Group updatedFakeGroup = new Group() { Id = 1, Name = "Group" };
            mockRepo.Setup(repo => repo.UpdateAsync(updatedFakeGroup.Id, updatedFakeGroup)).ReturnsAsync(true);
            controller = new GroupsController(mockRepo.Object);

            IActionResult actionResult = controller.Put(updatedFakeGroup.Id, updatedFakeGroup).Result;

            Assert.NotNull(actionResult);

            NoContentResult result = actionResult as NoContentResult;

            Assert.NotNull(result);
            // Verify Update was called
            mockRepo.Verify(repo => repo.UpdateAsync(updatedFakeGroup.Id, updatedFakeGroup));
        }

        [Fact]
        public void Update_InvalidId_ShouldReturnNotFound()
        {
            Group updatedFakeGroup = new Group() { Id = 10, Name = "Group" };
            controller = new GroupsController(mockRepo.Object);

            IActionResult actionResult = controller.Put(updatedFakeGroup.Id, updatedFakeGroup).Result;

            Assert.NotNull(actionResult);

            NotFoundResult result = actionResult as NotFoundResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void Delete_ValidId_ShouldReturnNoContent()
        {
            mockRepo.Setup(repo => repo.GetByIdAsync(fakeGroup.Id)).ReturnsAsync(fakeGroup);
            mockRepo.Setup(repo => repo.DeleteAsync(fakeGroup.Id)).ReturnsAsync(true);
            controller = new GroupsController(mockRepo.Object);

            IActionResult actionResult = controller.Delete(fakeGroup.Id).Result;

            Assert.NotNull(actionResult);

            NoContentResult result = actionResult as NoContentResult;

            Assert.NotNull(result);
            // Verify Delete was called
            mockRepo.Verify(repo => repo.DeleteAsync(fakeGroup.Id));
        }

        [Fact]
        public void Delete_InvalidId_ShouldReturnNotFound()
        {
            Group invalidFakeGroup = new Group() { Id = 10, Name = "Group" };
            mockRepo.Setup(repo => repo.DeleteAsync(fakeGroup.Id)).ReturnsAsync(true);
            controller = new GroupsController(mockRepo.Object);

            IActionResult actionResult = controller.Delete(invalidFakeGroup.Id).Result;

            Assert.NotNull(actionResult);

            NotFoundResult result = actionResult as NotFoundResult;

            Assert.NotNull(result);
        }
    }
}