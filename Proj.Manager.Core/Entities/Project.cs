using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Exceptions.Common;
using Proj.Manager.Core.Primitives;
using Proj.Manager.Core.ValueObjects;

namespace Proj.Manager.Core.Entities
{
    public sealed class Project : Entity
    {

        public Project()
        { }

        public Project(
            Member member,
            Name name, 
            Description description)
        {
            this.Name = name;
            this.Description = description;
            this.ManagerId = member.Id;
        }

        public Guid ManagerId { get; private set; }
        public Name Name { get; private set; } = null!;
        public Description Description { get; private set; } = null!;
        public DateTime? StartDate { get; private set; }
        public DateTime? FinishDate { get; private set; }
        public ProjectStatus Status { get; private set; } = ProjectStatus.ToDo;

        public bool IsCompleted => this.Status == ProjectStatus.Completed;
        public bool IsTodo => this.Status == ProjectStatus.ToDo;
        public bool IsOnGoing => this.Status == ProjectStatus.OnGoing;
        public bool IsCanceled => this.Status == ProjectStatus.Canceled;
        public bool IsDeleted => this.Status == ProjectStatus.Deleted;

        public List<Task> Tasks { get; private set; } = new();
        public Member Manager { get; private set; } = null!;

        public void Update(
            Name? name = null,
            Description? description = null)
        {
            if (!IsOnGoing && !IsTodo)
                throw new DomainLayerException(DomainExceptionType.InvalidProjectStatus, "Can not update the project. It got to be on 'ongoing' or 'todo' status.");

            if (name != null) this.Name = name;
            if (description != null) this.Description = description;
        }
        public void AddTask(
            Name name,
            Description description) {

            if (!IsOnGoing && !IsTodo) 
                throw new DomainLayerException(DomainExceptionType.InvalidProjectStatus, "Can not add task to the project. It got to be on 'ongoing' or 'todo' status.");

            var task = new Task(this, name, description);

            this.Tasks.Add(task);

            if (Status == ProjectStatus.ToDo) Status = ProjectStatus.OnGoing;
        }
        public void RemoveTask(Guid taskId)
        {
            if (!IsOnGoing && !IsTodo)
                throw new DomainLayerException(DomainExceptionType.InvalidProjectStatus, "Can not remove task from the project. It got to be on 'ongoing' or 'todo' status.");

            var task = Tasks.SingleOrDefault(x => x.Id == taskId) ?? throw new Exception("Task not found on this project.");

            Tasks.Remove(task);

            if (Tasks.Count == 0) Status = ProjectStatus.ToDo;
        }
        public void Delete()
        {
            if (IsDeleted || IsCompleted) return;

            Tasks.ForEach(t => t.Delete());

            Status = ProjectStatus.Deleted;
            FinishDate = DateTime.Now;
        }
        public void Finish()
        {
            if (!IsOnGoing) return;

            if (Tasks.Any(x => x.Status == Enums.TaskStatus.ToDo || x.Status == Enums.TaskStatus.OnGoing))
                throw new DomainLayerException(DomainExceptionType.InvalidTaskStatus, "You can not finish this project. There are both 'on going' or 'to do' tasks on it.");

            Status = ProjectStatus.Completed;
            FinishDate = DateTime.Now;
        }
        public void Cancel()
        {
            if (IsCanceled || IsCompleted || IsDeleted) return;

            Tasks.ForEach(t => t.Delete());

            Status = ProjectStatus.Canceled;
            FinishDate = DateTime.Now;
        }
    }
}
