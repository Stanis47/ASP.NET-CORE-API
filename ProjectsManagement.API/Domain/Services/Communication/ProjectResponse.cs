using ProjectsManagement.API.Domain.Models;

namespace ProjectsManagement.API.Domain.Services.Communication
{
    public class ProjectResponse : BaseResponse
    {
        public Project Project { get; private set; }

        private ProjectResponse(bool success, string message, Project project) : base(success, message)
        {
            Project = project;
        }

        public ProjectResponse(Project project) : this(true, string.Empty, project) { }

        public ProjectResponse(string message) : this(false, message, null) { }
    }
}
