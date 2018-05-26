using System;
using Xunit;
using Moq;
using Collab.API.Models;
using Collab.API.DAL;
using Collab.API.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Collab.API.Tests.Controllers
{
    public class UsersControllerTest : IDisposable
    {
        private User fakeUser;
        private Mock<IRepository<User>> mockRepo;

        public UsersControllerTest()
        {
            fakeUser = new User { Id = 1, Nickname = "Gerald" };
            mockRepo = new Mock<IRepository<User>>();
        }

        public void Dispose()
        {
            fakeUser = null;
            mockRepo = null;
        }

        [Fact]
        public void Get_AllUsers_ShouldReturnEnumerableOfUsers()
         {
            var fakeUsers = new List<User> { fakeUser };
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(fakeUsers);
            var controller = new UsersController(mockRepo.Object);

            IActionResult actionResult = controller.Get().Result;
            
            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;

            IEnumerable<User> users = result.Value as IEnumerable<User>;
            var enumerator = users.GetEnumerator();
            enumerator.MoveNext();

            Assert.NotNull(users);
            Assert.Equal(fakeUser.Id, enumerator.Current.Id);
        }

        [Fact]
        public void Get_ByValidId_ShouldReturnAUser()
        {
            mockRepo.Setup(repo => repo.GetByIdAsync(fakeUser.Id)).ReturnsAsync(fakeUser);
            var controller = new UsersController(mockRepo.Object);

            IActionResult actionResult = controller.Get(fakeUser.Id).Result;

            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;
            User userResult = result.Value as User;

            Assert.NotNull(userResult);
            Assert.Equal(fakeUser.Id, userResult.Id);
        }

        [Fact]
        public void Get_ByInvalidId_ShouldReturnNotFound()
        {
            var controller = new UsersController(mockRepo.Object);

            IActionResult actionResult = controller.Get(1234).Result;

            Assert.NotNull(actionResult);

            NotFoundResult result = actionResult as NotFoundResult;
            
            Assert.NotNull(result);
        }

        [Fact]
        public void Create_ValidUser_ShouldReturnCreatedAt()
        {
            var controller = new UsersController(mockRepo.Object);

            IActionResult actionResult = controller.Post(fakeUser).Result;

            Assert.NotNull(actionResult);

            CreatedAtActionResult result = actionResult as CreatedAtActionResult;
            var routeValues = result.RouteValues;

            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(fakeUser.Id, routeValues["Id"]);
            mockRepo.Verify(repo => repo.CreateAsync(fakeUser));
        }

        [Fact]
        public void Update_ValidId_ShouldReturnNoContent()
        {
            mockRepo.Setup(repo => repo.GetByIdAsync(fakeUser.Id)).ReturnsAsync(fakeUser);
            User updatedFakeUser = new User() { Id = 1, Nickname = "James" };
            mockRepo.Setup(repo => repo.UpdateAsync(updatedFakeUser.Id, updatedFakeUser)).ReturnsAsync(true);
            var controller = new UsersController(mockRepo.Object);

            IActionResult actionResult = controller.Put(updatedFakeUser.Id, updatedFakeUser).Result;

            Assert.NotNull(actionResult);

            NoContentResult result = actionResult as NoContentResult;

            Assert.NotNull(result);
            // Verify Update was called
            mockRepo.Verify(repo => repo.UpdateAsync(updatedFakeUser.Id, updatedFakeUser));
        }

        [Fact]
        public void Update_InvalidId_ShouldReturnNotFound()
        {
            User updatedFakeUser = new User() { Id = 10, Nickname = "James" };
            var controller = new UsersController(mockRepo.Object);

            IActionResult actionResult = controller.Put(updatedFakeUser.Id, updatedFakeUser).Result;

            Assert.NotNull(actionResult);

            NotFoundResult result = actionResult as NotFoundResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void Delete_ValidId_ShouldReturnNoContent()
        {
            mockRepo.Setup(repo => repo.GetByIdAsync(fakeUser.Id)).ReturnsAsync(fakeUser);
            mockRepo.Setup(repo => repo.DeleteAsync(fakeUser.Id)).ReturnsAsync(true);
            var controller = new UsersController(mockRepo.Object);

            IActionResult actionResult = controller.Delete(fakeUser.Id).Result;

            Assert.NotNull(actionResult);

            NoContentResult result = actionResult as NoContentResult;

            Assert.NotNull(result);
            // Verify Delete was called
            mockRepo.Verify(repo => repo.DeleteAsync(fakeUser.Id));
        }

        [Fact]
        public void Delete_InvalidId_ShouldReturnNotFound()
        {
            User invalidFakeUser = new User() { Id = 10, Nickname = "Gerald" };
            mockRepo.Setup(repo => repo.DeleteAsync(fakeUser.Id)).ReturnsAsync(true);
            var controller = new UsersController(mockRepo.Object);

            IActionResult actionResult = controller.Delete(invalidFakeUser.Id).Result;

            Assert.NotNull(actionResult);

            NotFoundResult result = actionResult as NotFoundResult;

            Assert.NotNull(result);
        }
    }
}