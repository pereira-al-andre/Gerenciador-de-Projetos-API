using AutoFixture;
using Moq;
using Proj.Manager.Application.DTO.RequestModels.Member;
using Proj.Manager.Application.DTO.ViewModels;
using Proj.Manager.Application.Exceptions.Common;
using Proj.Manager.Application.Services;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Exceptions;
using Proj.Manager.Core.Exceptions.Common;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Core.ValueObjects;
using Shouldly;

namespace Proj.Manager.Tests
{
    public class CreateUserTest
    {
        private readonly IMemberRepository _memberRepositoy;
        private readonly IMemberService _memberService;
        private readonly Mock<IMemberRepository> _memberRepositoyMock;

        private CreateMemberRequest _validMemberRequest;
        private Member _expectedMember;

        public CreateUserTest()
        {
            _validMemberRequest = new Fixture().Create<CreateMemberRequest>();

            _expectedMember = new Member(
             new Name(_validMemberRequest.Name),
             new Email(_validMemberRequest.Email),
             new Password(_validMemberRequest.Password),
             _validMemberRequest.Role);

            var viewModel = new MemberViewModel(_expectedMember);

            _memberRepositoyMock = new Mock<IMemberRepository>();
            _memberRepositoyMock.Setup(x => x.Create(It.IsAny<Member>())).Returns(_expectedMember);
            _memberRepositoy = _memberRepositoyMock.Object;

            _memberService = new MemberService(_memberRepositoy);

        }

        [Fact]

        public void ValidDeveloperMember_CreateCalled_ReturnValidMemberViewModel()
        {
            var member = _memberService.Create(_validMemberRequest);

            member.Name.ShouldBe(_expectedMember.Name.Value);
            member.Email.ShouldBe(_expectedMember.Email.Value);
            member.Role.ShouldBe(_expectedMember.Role);

            _memberRepositoyMock.Verify(m => m.Create(It.IsAny<Member>()), Times.Once);
        }

        [Fact]
        public void InvalidEmailDeveloperMember_CreateCalled_ReturnException()
        {
            var invalidMember = new CreateMemberRequest("Invalid Member", "", "senha", Role.Developer);

            Should.Throw(() => _memberService.Create(invalidMember), typeof(InvalidEmailException), "Invalid email");
        }

        [Fact]
        public void InvalidPasswordDeveloperMember_CreateCalled_ReturnException()
        {
            Should.Throw(() => _memberService.Create(invalidRequest), typeof(DomainLayerException), "Invalid argument passed");
        }
    }
}