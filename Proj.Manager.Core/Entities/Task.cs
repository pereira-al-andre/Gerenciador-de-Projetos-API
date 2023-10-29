using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Primitives;
using Proj.Manager.Core.ValueObjects;

namespace Proj.Manager.Core.Entities
{
    public sealed class Task : Entity
    {
        internal Task()
        {
            
        }

        internal Task(
            Project project,
            Name name, 
            Description description)
        {
            this.ProjectId = project.Id;
            this.Name = name;
            this.Description = description;

        }

        public Guid ProjectId { get; private set; }
        public Name Name { get; private set; } = null!;
        public Description Description { get; private set; } = null!;
        public DateTime? StartDate { get; private set; }
        public DateTime? FinishDate { get; private set; }
        public Enums.TaskStatus Status { get; private set; } = Enums.TaskStatus.ToDo;
        public List<Member> Members { get; private set; } = new();
        public Project Project { get; private set; } = null!;

        public bool IsToDo => Status == Enums.TaskStatus.ToDo;
        public bool IsOnGoing => Status == Enums.TaskStatus.OnGoing;
        public bool IsCompleted => Status == Enums.TaskStatus.Completed;
        public bool IsDeleted => Status == Enums.TaskStatus.Deleted;

        public void Update(
           Name? name = null,
           Description? description = null)
        {

            if (IsCompleted)
                throw new Exception("You can not update a completed task.");

            if (IsDeleted)
                throw new Exception("You can not update a deleted task.");

            if (name != null) this.Name = name;
            if (description != null) this.Description = description;
        }
        public void AddMember(Member member)
        {
            if (IsCompleted)
                throw new Exception("You can not add members to a completed task.");

            if (IsDeleted)
                throw new Exception("You can not add members to a deleted task.");

            this.Members.Add(member);
        }
        public void RemoveMember(Member member)
        {
            if (IsCompleted)
                throw new Exception("You can not remove members to a completed task.");

            if (IsDeleted)
                throw new Exception("You can not remove members to a deleted task.");

            this.Members.Remove(member);

            if (this.Members.Count == 0) this.Status = Enums.TaskStatus.ToDo;
        }
        public void Delete()
        {
            if (IsDeleted || IsCompleted) return;

            this.Status = Enums.TaskStatus.Deleted;
            this.FinishDate = DateTime.Now;
        }
        public void Complete()
        {
            if (!IsOnGoing) return;

            this.Status = Enums.TaskStatus.Completed;
            this.FinishDate = DateTime.Now;
        }
        public void Start()
        {
            if (!IsToDo) return;
            
            this.Status = Enums.TaskStatus.OnGoing;
            this.StartDate = DateTime.Now;
        }
    }
}
