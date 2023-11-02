using Moq;
using Proj.Manager.Application.DTO.RequestModels.Member;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Application.Services;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;
using Shouldly;
using Proj.Manager.Core.Enums;
using Proj.Manager.Core.ValueObjects;

namespace Proj.Manager.Tests.MemberTests
{
    public class UpdateRoleTestModel : TheoryData<UpdateRoleRequest, Member>
    {
        private readonly Member _expectedMemberManager;
        private readonly Member _expectedMemberDeveloper;
        public UpdateRoleTestModel()
        {
            _expectedMemberManager = new Member(
                new Name("Name"),
                new Email("mail@mail.com"),
                new Password("password"),
                Role.Manager);

            _expectedMemberDeveloper = new Member(
                new Name("Name"),
                new Email("mail@mail.com"),
                new Password("password"),
                Role.Developer);

            Add(new UpdateRoleRequest(_expectedMemberManager.Id, Role.Manager), _expectedMemberManager);
            Add(new UpdateRoleRequest(_expectedMemberDeveloper.Id, Role.Developer), _expectedMemberDeveloper);
        }
    }

    public class UpdateRoleTeste
    {

        protected readonly Mock<IMemberRepository> _memberRepositoryMock;
        protected readonly IMemberService _memberService;

        public UpdateRoleTeste()
        {
            _memberRepositoryMock = new Mock<IMemberRepository>();
            _memberService = new MemberService(_memberRepositoryMock.Object);
        }

        [Theory]
        [ClassData(typeof(UpdateRoleTestModel))]
        public void Update_Should_ReturnVoid_WhenPassingValidUpdateRoleRequest(UpdateRoleRequest request, Member expectedMember)
        {

            _memberRepositoryMock.Setup(x => x.Find(It.IsAny<Guid>())).Returns(expectedMember);

            expectedMember.Role.ShouldBe(request.Role);
        }
    }
}
