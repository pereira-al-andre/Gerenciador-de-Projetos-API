using Proj.Manager.Application.Exceptions;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Repositories;
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

        public void UpdateRole(Member member)
        {
            try
            {
                _repository.Update(member);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdatePassword(Member member)
        {
            try
            {
                _repository.Update(member);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Member member)
        {
            try
            {
                _repository.Update(member);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Member Find(Guid id)
        {
            try
            {
                var member = _repository.Find(id);

                if (member == null)
                    throw new MemberNotFoundException("Member not found.");

                return member;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Member Create(Member member)
        {
            try
            {
                return _repository.Create(member);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Member> All()
        {
            try
            {
                return _repository.All();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Member> ListTaskMembers(Guid taskId)
        {
            try
            {
                var task = _taskRepository.Find(taskId);

                if (task == null)
                    throw new TaskNotFoundException("Task not found");

                return task.Members;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
