using System;

namespace ProjectsManagement.API.Resources
{
    public class ProjectForProgrammerListingResource
    {
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
