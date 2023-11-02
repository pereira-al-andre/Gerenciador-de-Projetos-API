using AutoFixture;
using Moq;
using Proj.Manager.Application.DTO.RequestModels.Project;
using Proj.Manager.Application.Services;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Exceptions.Common;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Core.ValueObjects;
using Shouldly;

namespace Proj.Manager.Tests.ProjectTests
{

    public class CreateProjectValidModelTest : TheoryData<CreateProjectRequest, Member>
    {
        public CreateProjectValidModelTest()
        {
            var expectedManager = new Fixture().Create<Member>();

            expectedManager.ChangeRole(Role.Manager);

            Add(new CreateProjectRequest(expectedManager.Id, "Project Name", "ProjectDescription"), expectedManager);
        }
    }

    public class CreateProjectInvalidModelTest : TheoryData<CreateProjectRequest, Member>
    {
        public CreateProjectInvalidModelTest()
        {
            var expectedManager = new Fixture().Create<Member>();

            expectedManager.ChangeRole(Role.Manager);

            Add(new CreateProjectRequest(expectedManager.Id, "", "ProjectDescription"), expectedManager);
            Add(new CreateProjectRequest(expectedManager.Id, "Project Name", ""), expectedManager);
        }
    }

    public class CreateProjectTest
    {
        private protected readonly IProjectService _projectService;
        private protected readonly IProjectRepository _projectRepository;

        private protected readonly IMemberRepository _memberRepositoy;

        private protected readonly Mock<IMemberRepository> _memberRepositoryMock;
        private protected readonly Mock<IProjectRepository> _projectRepositoryMock;


        public CreateProjectTest()
        {
            _projectRepositoryMock = new Mock<IProjectRepository>();
            _projectRepository = _projectRepositoryMock.Object;

            _memberRepositoryMock = new Mock<IMemberRepository>();
            _memberRepositoy = _memberRepositoryMock.Object;

            _projectService = new ProjectService(_projectRepository, _memberRepositoy);
        }

        [Theory]
        [ClassData(typeof(CreateProjectValidModelTest))]
        public void Create_Should_ReturnProject_WhenRequestIsValid(CreateProjectRequest request, Member owner)
        {
            _memberRepositoryMock.Setup(x => x.Find(It.IsAny<Guid>())).Returns(owner);

            var expectedProject = new Project(owner, new Name(request.Name), new Description(request.Description));

            _projectRepositoryMock.Setup(x => x.Create(It.IsAny<Project>())).Returns(expectedProject);

            var projectViewModel = _projectService.Create(request);

            projectViewModel.Name.ShouldBe(request.Name);
            projectViewModel.Description.ShouldBe(request.Description);
            projectViewModel.ManagerId.ShouldBe(owner.Id);
        }

        [Theory]
        [ClassData(typeof(CreateProjectInvalidModelTest))]
        public void Create_Should_ReturnArgumentException_WhenRequestIsInvalid(CreateProjectRequest request, Member owner)
        {
            _memberRepositoryMock.Setup(x => x.Find(It.IsAny<Guid>())).Returns(owner);

            Should.Throw(() => _projectService.Create(request), typeof(DomainLayerException), "Invalid argument");
        }
    }
}
