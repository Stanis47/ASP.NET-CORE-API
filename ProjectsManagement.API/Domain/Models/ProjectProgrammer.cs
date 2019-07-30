namespace ProjectsManagement.API.Domain.Models
{
    public class ProjectProgrammer
    {
        
        public int ProjectID { get; set; }
        public Project Project { get; set; }
        public int ProgrammerID { get; set; }
        public Programmer Programmer { get; set; }
    }
}
