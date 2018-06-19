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
    public class ProjectsControllerTest : IDisposable
    {
        private Project fakeProject;
        private Mock<IRepository<Project>> mockRepo;
        private ProjectsController controller;

        public ProjectsControllerTest()
        {
            fakeProject = new Project { Id = 1, Name = "Test" };
            mockRepo = new Mock<IRepository<Project>>();
        }

        public void Dispose()
        {
            fakeProject = null;
            mockRepo = null;
            controller = null;
        }

        [Fact]
        public void Get_AllProjects_ShouldReturnEnumerableOfProjects()
         {
            var fakeProjects = new List<Project> { fakeProject };
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(fakeProjects);
            controller = new ProjectsController(mockRepo.Object);

            IActionResult actionResult = controller.Get().Result;
            
            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;

            IEnumerable<Project> Projects = result.Value as IEnumerable<Project>;
            var enumerator = Projects.GetEnumerator();
            enumerator.MoveNext();

            Assert.NotNull(Projects);
            Assert.Equal(fakeProject.Id, enumerator.Current.Id);
        }

        [Fact]
        public void Get_ByValidId_ShouldReturnAProject()
        {
            mockRepo.Setup(repo => repo.GetByIdAsync(fakeProject.Id)).ReturnsAsync(fakeProject);
            controller = new ProjectsController(mockRepo.Object);

            IActionResult actionResult = controller.Get(fakeProject.Id).Result;

            Assert.NotNull(actionResult);

            OkObjectResult result = actionResult as OkObjectResult;
            Project ProjectResult = result.Value as Project;

            Assert.NotNull(ProjectResult);
            Assert.Equal(fakeProject.Id, ProjectResult.Id);
        }

        [Fact]
        public void Get_ByInvalidId_ShouldReturnNotFound()
        {
            controller = new ProjectsController(mockRepo.Object);

            IActionResult actionResult = controller.Get(1234).Result;

            Assert.NotNull(actionResult);

            NotFoundResult result = actionResult as NotFoundResult;
            
            Assert.NotNull(result);
        }

        [Fact]
        public void Create_ValidProject_ShouldReturnCreatedAt()
        {
            controller = new ProjectsController(mockRepo.Object);

            IActionResult actionResult = controller.Post(fakeProject).Result;

            Assert.NotNull(actionResult);

            CreatedAtActionResult result = actionResult as CreatedAtActionResult;
            var routeValues = result.RouteValues;

            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(fakeProject.Id, routeValues["Id"]);
            mockRepo.Verify(repo => repo.CreateAsync(fakeProject));
        }

        [Fact]
        public void Update_ValidId_ShouldReturnNoContent()
        {
            mockRepo.Setup(repo => repo.GetByIdAsync(fakeProject.Id)).ReturnsAsync(fakeProject);
            Project updatedFakeProject = new Project() { Id = 1, Name = "Test 2" };
            mockRepo.Setup(repo => repo.UpdateAsync(updatedFakeProject.Id, updatedFakeProject)).ReturnsAsync(true);
            controller = new ProjectsController(mockRepo.Object);

            IActionResult actionResult = controller.Put(updatedFakeProject.Id, updatedFakeProject).Result;

            Assert.NotNull(actionResult);

            NoContentResult result = actionResult as NoContentResult;

            Assert.NotNull(result);
            // Verify Update was called
            mockRepo.Verify(repo => repo.UpdateAsync(updatedFakeProject.Id, updatedFakeProject));
        }

        [Fact]
        public void Update_InvalidId_ShouldReturnNotFound()
        {
            Project updatedFakeProject = new Project() { Id = 10, Name = "Test 2" };
            controller = new ProjectsController(mockRepo.Object);

            IActionResult actionResult = controller.Put(updatedFakeProject.Id, updatedFakeProject).Result;

            Assert.NotNull(actionResult);

            NotFoundResult result = actionResult as NotFoundResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void Delete_ValidId_ShouldReturnNoContent()
        {
            mockRepo.Setup(repo => repo.GetByIdAsync(fakeProject.Id)).ReturnsAsync(fakeProject);
            mockRepo.Setup(repo => repo.DeleteAsync(fakeProject.Id)).ReturnsAsync(true);
            controller = new ProjectsController(mockRepo.Object);

            IActionResult actionResult = controller.Delete(fakeProject.Id).Result;

            Assert.NotNull(actionResult);

            NoContentResult result = actionResult as NoContentResult;

            Assert.NotNull(result);
            // Verify Delete was called
            mockRepo.Verify(repo => repo.DeleteAsync(fakeProject.Id));
        }

        [Fact]
        public void Delete_InvalidId_ShouldReturnNotFound()
        {
            Project invalidFakeProject = new Project() { Id = 10, Name = "Test 2" };
            mockRepo.Setup(repo => repo.DeleteAsync(fakeProject.Id)).ReturnsAsync(true);
            controller = new ProjectsController(mockRepo.Object);

            IActionResult actionResult = controller.Delete(invalidFakeProject.Id).Result;

            Assert.NotNull(actionResult);

            NotFoundResult result = actionResult as NotFoundResult;

            Assert.NotNull(result);
        }
    }
}