using AutoMapper;
using ProjectsManagement.API.Domain.Models;
using ProjectsManagement.API.Resources;

namespace ProjectsManagement.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveProjectResource, Project>();
            CreateMap<SaveProgrammerResource, Programmer>();

            CreateMap<ProjectForListingResource, Project>();
            CreateMap<ProjectProgrammerForProjectResource, ProjectProgrammer>();
            CreateMap<ProgrammerForProjectListingResource, Programmer>();
        }
    }
}
