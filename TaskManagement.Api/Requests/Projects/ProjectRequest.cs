namespace TaskManagement.Api.Requests.Projects
{
    public class CreateProjectRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class UpdateProjectRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
