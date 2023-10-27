using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Primitives;
using Proj.Manager.Core.ValueObjects;

namespace Proj.Manager.Core.Entities
{
    public sealed class Project : Entity
    {

        public Project()
        {
            
        }

        public Project(
            Guid managerId,
            Name name, 
            Description description, 
            DateTime startDate, 
            DateTime endDate)
        {
            this.Name = name;
            this.Description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.ManagerId = managerId;
        }

        public Project(
            Guid managerId,
            Name name,
            Description description,
            DateTime startDate)
        {
            this.Name = name;
            this.Description = description;
            this.StartDate = startDate;
            this.EndDate = startDate.AddDays(15);
            this.ManagerId = managerId;
        }

        public Guid ManagerId { get; set; }
        public Name Name { get; set; }
        public Description Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? FinishDate { get; set; } = null;
        public ProjectStatus Status { get; set; } = ProjectStatus.ToDo;

        public List<Task> Tasks { get; set; } = new();
        public Member Manager { get; set; } = null!;

        public void Update(
            Name? name = null,
            Description? description = null,
            DateTime? endDate = null)
        {
            if (name != null) this.Name = name;
            if (description != null) this.Description = description;
            if (endDate != null) this.EndDate = endDate.Value;
        }

        public void AddTask(Task task) => this.Tasks.Add(task);

        public void RemoveTask(Task task) => this.Tasks.Remove(task);

        public void Delete()
        {
            this.Status = ProjectStatus.Deleted;
            this.FinishDate = DateTime.Now;
        }

        public void Finish()
        {
            this.Status = ProjectStatus.Completed;
            this.FinishDate = DateTime.Now;
        }

        public void Cancel()
        {
            this.Status = ProjectStatus.Canceled;
            this.FinishDate = DateTime.Now;
        }

        public void Start()
        {
            this.Status = ProjectStatus.OnGoing;
        }
    }
}
