using Proj.Manager.Application.DTO.RequestModels.Member;
using Proj.Manager.Application.DTO.ViewModels;
using Proj.Manager.Application.Enums;
using Proj.Manager.Application.Exceptions;
using Proj.Manager.Application.Exceptions.Common;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Core.ValueObjects;
using System;

namespace Proj.Manager.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repository;
        public MemberService(
            IMemberRepository memberRepository)
        {
            _repository = memberRepository;
        }

        public void UpdateRole(UpdateRoleRequest request)
        {
            try
            {
                var member = _repository.Find(request.Id) ?? throw new ApplicationLayerException(ApplicationExceptionType.MemberNotFound);
                member.ChangeRole(request.Role);

                _repository.Update(member);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdatePassword(UpdatePasswordRequest request)
        {
            try
            {
                var member = _repository.Find(request.Id) ?? throw new ApplicationLayerException(ApplicationExceptionType.MemberNotFound);
                member.ChangePassword(new Password(request.NewPassword));

                _repository.Update(member);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(UpdateMemberRequest request)
        {
            try
            {
                var member = _repository.Find(request.Id) ?? throw new ApplicationLayerException(ApplicationExceptionType.MemberNotFound);

                if (request.Name != null) member.Update(new Name(request.Name));
                if (request.Email != null) member.Update(null, new Email(request.Email));

                _repository.Update(member);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MemberViewModel Find(Guid id)
        {
            try
            {
                var member = _repository.Find(id) ?? throw new ApplicationLayerException(ApplicationExceptionType.MemberNotFound);

                return new MemberViewModel(member);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MemberViewModel Create(CreateMemberRequest request)
        {
            try
            {
                var member = new Member(
                new Name(request.Name),
                new Email(request.Email),
                new Password(request.Password),
                request.Role);

                return new MemberViewModel(_repository.Create(member));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<MemberViewModel> All()
        {
            try
            {
                return MemberViewModel.MembersList(_repository.All().ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TaskViewModel> ListMemberTasks(Guid memberId)
        {
            try
            {
                var member = _repository.Find(memberId, "Tasks") ?? throw new ApplicationLayerException(ApplicationExceptionType.MemberNotFound);

                return TaskViewModel.TasksList(member.Tasks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ProjectViewModel> ListMemberProjects(Guid memberId)
        {
            try
            {
                var member = _repository.Find(memberId, "Projects") ?? throw new ApplicationLayerException(ApplicationExceptionType.MemberNotFound);

                return ProjectViewModel.ProjectsList(member.Projects);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
