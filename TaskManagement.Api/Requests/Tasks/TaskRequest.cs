using TaskManagement.Domain.Entities.Projects;
using TaskManagement.Domain.Entities.Tasks;

namespace TaskManagement.Api.Requests.Tasks
{
    public class CreateTaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public DateOnly DueDate { get; set; }
        public Guid ProjectId { get; set; }
    }
    public class UpdateTaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public DateOnly DueDate { get; set; }
        
    }
}
