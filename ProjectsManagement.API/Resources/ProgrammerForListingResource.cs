using System;
using System.Collections.Generic;

namespace ProjectsManagement.API.Resources
{
    public class ProgrammerForListingRespurce
    {
        public int ProgrammerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }

        public List<ProjectProgrammerForProgrammerResource> Projects { get; set; }
    }
}
