using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectsManagement.API.Resources
{
    public class SaveProgrammerResource
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
