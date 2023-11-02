using AutoFixture;
using Moq;
using Proj.Manager.Application.DTO.RequestModels.Project;
using Proj.Manager.Application.Exceptions.Interfaces;
using Proj.Manager.Application.Services;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Exceptions.Common;
using Proj.Manager.Core.Exceptions.Interfaces;
using Proj.Manager.Core.Repositories;
using Shouldly;

namespace Proj.Manager.Tests.ProjectTests
{
    public class UpdateProjectValidModelTest : TheoryData<UpdateProjectRequest, Project>
    {
        public UpdateProjectValidModelTest()
        {
            var fixture = new Fixture();

            var expectedProject = fixture.Create<Project>();

            Add(new UpdateProjectRequest(expectedProject.Id, "New Name", "New Description"), expectedProject);
        }
    }

    public class UpdateProjectInvalidModelTest : TheoryData<UpdateProjectRequest, Project>
    {
        public UpdateProjectInvalidModelTest()
        {
            var fixture = new Fixture();

            var expectedProject = fixture.Create<Project>();

            Add(new UpdateProjectRequest(expectedProject.Id, "", "New Description"), expectedProject);
            Add(new UpdateProjectRequest(expectedProject.Id, "New Name", ""), expectedProject);
        }
    }

    public class UpdateProjectTest
    {
        private protected readonly IProjectRepository _projectRepository;
        private protected readonly Mock<IProjectRepository> _projectRepositoryMock;
        private protected readonly IProjectService _projectService;

        private protected readonly IMemberRepository _memberRepository;
        private protected readonly Mock<IMemberRepository> _memberRepositoryMock;
        public UpdateProjectTest()
        {
            _projectRepositoryMock = new Mock<IProjectRepository>();
            _projectRepository = _projectRepositoryMock.Object;

            _memberRepositoryMock = new Mock<IMemberRepository>();
            _memberRepository = _memberRepositoryMock.Object;

            _projectService = new ProjectService(_projectRepository, _memberRepository);
        }

        [Theory]
        [ClassData(typeof(UpdateProjectValidModelTest))]
        public void Update_Should_UpdateProject_WhenRequestIsValid(UpdateProjectRequest request, Project expectedProject)
        {
            _projectRepositoryMock.Setup(x => x.Find(It.IsAny<Guid>())).Returns(expectedProject);

            _projectService.Update(request);

            expectedProject.Name.Value.ShouldBe(request.Name);
            expectedProject.Description.Value.ShouldBe(request.Description);
        }

        [Theory]
        [ClassData(typeof(UpdateProjectInvalidModelTest))]
        public void Update_Should_ReturnException_WhenRequestIsInvalid(UpdateProjectRequest request, Project expectedProject)
        {
            _projectRepositoryMock.Setup(x => x.Find(It.IsAny<Guid>())).Returns(expectedProject);

            Should.Throw(() => _projectService.Update(request), typeof(DomainLayerException), "Invalid request");
        }
    }
}
