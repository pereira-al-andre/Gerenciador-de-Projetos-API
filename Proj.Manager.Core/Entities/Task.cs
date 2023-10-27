using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Primitives;
using Proj.Manager.Core.ValueObjects;

namespace Proj.Manager.Core.Entities
{
    public sealed class Task : Entity
    {
        public Task()
        {
            
        }

        public Task(
            Guid projectId,
            Name name, 
            Description description, 
            DateTime startDate, 
            DateTime? endDate)
        {
            this.ProjectId = projectId;
            this.Name = name;
            this.Description = description;
            this.StartDate = startDate;

            this.EndDate = endDate == null ? startDate.AddDays(15) : endDate.Value;

        }

        public Guid ProjectId { get; private set; }
        public Name Name { get; private set; } = null!;
        public Description Description { get; private set; } = null!;
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime? FinishDate { get; private set; } = null;
        public Enums.TaskStatus Status { get; private set; } = Enums.TaskStatus.ToDo;
        public List<Member> Members { get; private set; } = new();
        public Project Project { get; private set; } = null!;
        

        public void Update(
           Name? name = null,
           Description? description = null,
           DateTime? endDate = null)
        {
            if (name != null) this.Name = name;
            if (description != null) this.Description = description;
            if (endDate != null) this.EndDate = endDate.Value;
        }

        public void AddMember(Member member)
        {
            this.Members.Add(member);
        }

        public void RemoveMember(Member member)
        {
            this.Members.Remove(member);
        }

        public void Delete()
        {
            this.Status = Enums.TaskStatus.Deleted;
            this.FinishDate = DateTime.Now;
        }

        public void Complete()
        {
            this.Status = Enums.TaskStatus.Completed;
            this.FinishDate = DateTime.Now;
        }

        public void Cancel()
        {
            this.Status = Enums.TaskStatus.Canceled;
            this.FinishDate = DateTime.Now;
        }

        public void Start()
        {
            this.Status = Enums.TaskStatus.OnGoing;
        }
    }
}
