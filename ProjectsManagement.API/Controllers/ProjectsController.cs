using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.API.Domain.Models;
using ProjectsManagement.API.Domain.Services;
using ProjectsManagement.API.Domain.Services.Communication;
using ProjectsManagement.API.Extensions;
using ProjectsManagement.API.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectsManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [EnableCors]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableCors]
        public async Task<IEnumerable<ProjectForListingResource>> GetAllAsync()
        {
             IEnumerable<Project> projects = await _projectService.ListAsync();
             IEnumerable<ProjectForListingResource> resources = _mapper.Map<IEnumerable<ProjectForListingResource>>(projects);

             return resources;  
        }

        [HttpGet("{id}")]
        [EnableCors]
        public async Task<IActionResult> Get(int id)
        {
            Project project = await _projectService.GetOneAsync(id);
             
            if (project == null)
            {
               return BadRequest(string.Format("Project with id {0} doesn't exist.", id));
            }

            ProjectForListingResource result = _mapper.Map<ProjectForListingResource>(project);

            return Ok(result);
        }

        [HttpPost]
        [EnableCors]
        public async Task<IActionResult> PostAsync([FromBody] SaveProjectResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            Project project = _mapper.Map<SaveProjectResource, Project>(resource);
            ProjectResponse result = await _projectService.SaveAsync(project);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            ProjectResource projectResource = _mapper.Map<Project, ProjectResource>(result.Project);

            return Ok(projectResource);
        }

        [HttpPut("{id}")]
        [EnableCors]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Project resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            ProjectResponse result = await _projectService.UpdateAsync(id, resource);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            ProjectResource projectResource = _mapper.Map<Project, ProjectResource>(result.Project);
            return Ok(projectResource);
        }

        [HttpDelete("{id}")]
        [EnableCors]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            ProjectResponse result = await _projectService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            ProjectResource projectResource = _mapper.Map<Project, ProjectResource>(result.Project);

            return Ok(projectResource);
        }
    }
}