using AutoFixture;
using Moq;
using Proj.Manager.Application.DTO.RequestModels.Member;
using Proj.Manager.Application.Services;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Core.ValueObjects;
using Shouldly;

namespace Proj.Manager.Tests.MemberTests
{
    public class UpdateTestModel : TheoryData<UpdateMemberRequest, Member>
    {
        private readonly Member _expectedMember;
        public UpdateTestModel()
        {
            _expectedMember = new Member(
                new Name("Name"),
                new Email("mail@mail.com"),
                new Password("password"),
                Role.Developer);

            Add(new UpdateMemberRequest(_expectedMember.Id, "", ""), _expectedMember);
            Add(new UpdateMemberRequest(_expectedMember.Id, "New name", ""), _expectedMember);
            Add(new UpdateMemberRequest(_expectedMember.Id, "", "password"), _expectedMember);
        }
    }

    public class UpdateUserTest
    {
        protected readonly Mock<IMemberRepository> _memberRepositoryMock;
        protected readonly IMemberService _memberService;

        public UpdateUserTest()
        {
            _memberRepositoryMock = new Mock<IMemberRepository>();
            _memberService = new MemberService(_memberRepositoryMock.Object);
        }

        [Theory]
        [ClassData(typeof(UpdateTestModel))]
        public void Update_Should_ReturnArgumentException_WhenNameOrEmailOrPasswordAreNull(UpdateMemberRequest request, Member expectedMember)
        {

            _memberRepositoryMock.Setup(x => x.Find(It.IsAny<Guid>())).Returns(expectedMember);

            Should.Throw(() => _memberService.Update(request), typeof(ArgumentException), "Invalid argument");
        }
    }
}
