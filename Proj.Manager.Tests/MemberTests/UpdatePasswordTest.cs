using Moq;
using Proj.Manager.Application.DTO.RequestModels.Member;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Application.Services;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Core.ValueObjects;
using Shouldly;
using Proj.Manager.Application.Exceptions.Common;
using Proj.Manager.Core.Exceptions.Common;

namespace Proj.Manager.Tests.MemberTests
{
    public class UpdatePasswordTestModel : TheoryData<UpdatePasswordRequest, Member>
    {
        private readonly Member _expectedMember;
        public UpdatePasswordTestModel()
        {
            _expectedMember = new Member(
                new Name("Name"),
                new Email("mail@mail.com"),
                new Password("password"),
                Role.Manager);

            Add(new UpdatePasswordRequest(_expectedMember.Id, "password", "newPassword"), _expectedMember);
            Add(new UpdatePasswordRequest(_expectedMember.Id, "password", ""), _expectedMember);
        }
    }
    public class UpdatePasswordTest
    {
        protected readonly Mock<IMemberRepository> _memberRepositoryMock;
        protected readonly IMemberService _memberService;

        public UpdatePasswordTest()
        {
            _memberRepositoryMock = new Mock<IMemberRepository>();
            _memberService = new MemberService(_memberRepositoryMock.Object);
        }


        [Theory]
        [ClassData(typeof(UpdatePasswordTestModel))]
        public void Update_Should_ReturnVoid_WhenPassingValidUpdatePasswordRequest_Or_ArumentExceptionForInvalid(UpdatePasswordRequest request, Member expectedMember)
        {

            _memberRepositoryMock.Setup(x => x.Find(It.IsAny<Guid>())).Returns(expectedMember);

            if (String.IsNullOrEmpty(request.NewPassword))
            {
                Should.Throw(() => _memberService.UpdatePassword(request), typeof(DomainLayerException), "Invalid password");
            }
            else
            {
                _memberService.UpdatePassword(request);
                expectedMember.Password.Value.ShouldBe(request.NewPassword);
            }
        }
    }
}
