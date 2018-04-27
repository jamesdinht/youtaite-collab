using System;
using Xunit;
using Moq;
using Collab.Models;
using Collab.DAL;
using Collab.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Collab.Tests.Controllers
{
    public class UserControllerTest : IDisposable
    {
        private User fakeUser;
        private Mock<IRepository<User>> mockRepo;

        public UserControllerTest()
        {
            fakeUser = new User { Id = Guid.Parse("12345678-90ab-cdef-1234-567890abcdef"), Nickname = "Gerald" };
            mockRepo = new Mock<IRepository<User>>();
        }

        public void Dispose()
        {
            fakeUser = null;
        }

        [Fact]
        public void GetAllUsers_ShouldReturnEnumerableOfUsers()
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
    }
}