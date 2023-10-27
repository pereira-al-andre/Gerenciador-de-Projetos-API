using Proj.Manager.Core.Entities;
using Proj.Manager.Core.Enums;
using Proj.Manager.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Proj.Manager.Application.DTO.ViewModels
{
    public class TaskMember
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public TaskMember(Member member)
        {
            this.Name = member.Name.Value;
            this.Id = member.Id;
        }
    }

    public class TaskViewModel
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? FinishDate { get; set; } = null;
        public Core.Enums.TaskStatus Status { get; set; } = Core.Enums.TaskStatus.ToDo;
        public string StatusDescription { get { return this.Status.GetDescription(); } }
        public List<TaskMember> Members { get; set; } = new();


        public TaskViewModel(Core.Entities.Task task)
        {
            this.Id = task.Id;
            this.ProjectId = task.ProjectId;
            this.Name = task.Name.Value;
            this.Description = task.Description.Value;
            this.StartDate = task.StartDate;
            this.EndDate = task.EndDate;
            this.FinishDate = task.FinishDate;
            this.Status = task.Status;

            this.LoadMembers(task);
           
        }
        public static List<TaskViewModel> TasksList(List<Core.Entities.Task> tasks)
        {

            var taskViewModelList = new List<TaskViewModel>();

            tasks.ForEach(t => taskViewModelList.Add(new TaskViewModel(t)));

            return taskViewModelList;
        }
        private void LoadMembers(Core.Entities.Task task) 
            => task.Members.ForEach(member => this.Members.Add(new TaskMember(member)));
    }
}
