using System.ComponentModel.DataAnnotations;

namespace ProjectsManagement.API.Resources
{
    public class SaveProjectResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [MaxLength(300)]
        public string FullDescription { get; set; }
    }
}
