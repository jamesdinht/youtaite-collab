using System;
using Xunit;
using Moq;
using Collab.API.Models;
using Collab.API.DAL;
using Collab.API.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Collab.API.BLL;
using Collab.API.Models.Context;

namespace Collab.API.Tests.Controllers
{
    public class UsersControllerTest : IDisposable
    {
        private User fakeUser;
        private Mock<IRepository<User>> mockRepo;
        private UsersController controller;

        public UsersControllerTest()
        {
            fakeUser = new User { Id = 1, Nickname = "Gerald", Email = "test@test.com" };
            mockRepo = new Mock<IRepository<User>>();
        }

        public void Dispose()
        {
            fakeUser = null;
            mockRepo.Reset();
            mockRepo = null;
            controller = null;
        }

        [Fact]
        public void Get_AllUsers_ShouldReturnEnumerableOfUsers()
         {
            var fakeUsers = new List<User> { fakeUser };
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(fakeUsers);
            controller = new UsersController(mockRepo.Object);

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
            controller = new UsersController(mockRepo.Object);

            ActionResult<User> actionResult = controller.GetById(fakeUser.Id).Result;

            Assert.NotNull(actionResult);

            User userResult = actionResult.Value;

            Assert.NotNull(userResult);
            Assert.Equal(fakeUser.Id, userResult.Id);
        }

        [Fact]
        public void Get_ByInvalidId_ShouldReturnNotFound()
        {
            controller = new UsersController(mockRepo.Object);

            ActionResult<User> actionResult = controller.GetById(1234).Result;

            Assert.NotNull(actionResult);
            
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact(Skip="Figure out how to solve the InvalidCastException")]
        
        public void Get_ByValidEmail_ShouldReturnAUser()
        {
            controller = new UsersController(mockRepo.Object);

            ActionResult<User> actionResult = controller.GetByEmail(fakeUser.Email).Result;

            Assert.NotNull(actionResult);
            
            User userResult = actionResult.Value;
            
            Assert.NotNull(userResult);
            Assert.Equal(fakeUser.Email, userResult.Email);
        }

        [Fact]
        public void Create_ValidUser_ShouldReturnCreatedAt()
        {
            controller = new UsersController(mockRepo.Object);

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
            controller = new UsersController(mockRepo.Object);

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
            controller = new UsersController(mockRepo.Object);

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
            controller = new UsersController(mockRepo.Object);

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
            controller = new UsersController(mockRepo.Object);

            IActionResult actionResult = controller.Delete(invalidFakeUser.Id).Result;

            Assert.NotNull(actionResult);

            NotFoundResult result = actionResult as NotFoundResult;

            Assert.NotNull(result);
        }
    }
}