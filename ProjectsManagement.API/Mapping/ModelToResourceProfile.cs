using AutoMapper;
using ProjectsManagement.API.Domain.Models;
using ProjectsManagement.API.Resources;

namespace ProjectsManagement.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Project, ProjectResource>();
            CreateMap<Programmer, ProgrammerResource>();

            CreateMap<Project, ProjectForListingResource>();
            CreateMap<ProjectProgrammer, ProjectProgrammerForProjectResource>();
            CreateMap<Programmer, ProgrammerForProjectListingResource>();

            CreateMap<Programmer, ProgrammerForListingRespurce>();
            CreateMap<ProjectProgrammer, ProjectProgrammerForProgrammerResource>();
            CreateMap<Project, ProjectForProgrammerListingResource>();
        }
    }
}
