using Proj.Manager.Application.DTO.RequestModels.Member;
using Proj.Manager.Application.DTO.ViewModels;
using Proj.Manager.Application.Exceptions;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;
using Proj.Manager.Core.ValueObjects;
using System;

namespace Proj.Manager.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepositoy _repository;
        private readonly ITaskRepository _taskRepository;
        public MemberService(
            IMemberRepositoy memberRepository,
            ITaskRepository taskRepository)
        {
            _repository = memberRepository;
            _taskRepository = taskRepository;
        }

        public void UpdateRole(UpdateRoleRequest request)
        {
            try
            {
                var member = _repository.Find(request.Id) ?? throw new Exception("Member not found");

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
                var member = _repository.Find(request.Id) ?? throw new Exception("Member not found");

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
                var member = _repository.Find(request.Id) ?? throw new Exception("Member not found");

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
                var member = _repository.Find(id) ?? throw new MemberNotFoundException("Member not found.");

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

        public List<MemberViewModel> ListTaskMembers(Guid taskId)
        {
            try
            {
                var task = _taskRepository.Find(taskId) ?? throw new TaskNotFoundException("Task not found");

                return MemberViewModel.MembersList(task.Members);
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
                var member = _repository.Find(memberId, "Tasks") ?? throw new MemberNotFoundException("Member not found.");

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
                var member = _repository.Find(memberId, "Projects") ?? throw new MemberNotFoundException("Member not found.");

                return ProjectViewModel.ProjectsList(member.Projects);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
