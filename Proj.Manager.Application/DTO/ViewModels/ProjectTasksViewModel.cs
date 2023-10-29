using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Extensions;

namespace Proj.Manager.Application.DTO.ViewModels
{
    public class ProjectTasks
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public ProjectTasks(Core.Entities.Task task)
        {
            this.Name = task.Name.Value;
            this.Id = task.Id;
        }
    }

    public class ProjectViewModel
    {
        public Guid Id { get; set; }
        public Guid ManagerId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public ProjectStatus Status { get; set; } = ProjectStatus.ToDo;
        public string StatusDescription { get { return this.Status.GetDescription(); } }

        public List<ProjectTasks> Tasks { get; set; } = new();

        public ProjectViewModel(Project project)
        {
            this.Id = project.Id;
            this.ManagerId = project.ManagerId;
            this.Name = project.Name.Value;
            this.Description = project.Description.Value;
            this.StartDate = project.StartDate;
            this.FinishDate = project.FinishDate;
            this.Status = project.Status;

            this.LoadTasks(project);
        }

        public static List<ProjectViewModel> ProjectsList(List<Project> projects)
        {

            var projectViewModelList = new List<ProjectViewModel>();
            projects.ForEach(p => projectViewModelList.Add(new ProjectViewModel(p)));

            return projectViewModelList;
        }

        public void LoadTasks(Project project) 
            => project.Tasks.ForEach(task => this.Tasks.Add(new ProjectTasks(task)));
    }
}
