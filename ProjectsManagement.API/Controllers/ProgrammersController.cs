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
    public class ProgrammersController : Controller
    {
        private readonly IProgrammerService _programmerService;
        private readonly IMapper _mapper;

        public ProgrammersController(IProgrammerService programmerService, IMapper mapper)
        {
            _programmerService = programmerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProgrammerForListingRespurce>> GetAllAsync()
        {
            IEnumerable<Programmer> programmers = await _programmerService.ListAsync();
            IEnumerable<ProgrammerForListingRespurce> resources = _mapper.Map<IEnumerable<ProgrammerForListingRespurce>>(programmers);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Programmer programmer = await _programmerService.GetOneAsync(id);

            if (programmer == null)
            {
                return BadRequest(string.Format("Programmer with id {0} doesn't exist.", id));
            }

            ProgrammerForListingRespurce result = _mapper.Map<ProgrammerForListingRespurce>(programmer);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProgrammerResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            Programmer programmer = _mapper.Map<SaveProgrammerResource, Programmer>(resource);
            ProgrammerResponse result = await _programmerService.SaveAsync(programmer);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            //ProgrammerResource programmerResource = _mapper.Map<Programmer, ProgrammerResource>(result.Programmer);

            return Ok(result.Programmer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProgrammerResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            Programmer programmer = _mapper.Map<SaveProgrammerResource, Programmer>(resource);
            ProgrammerResponse result = await _programmerService.UpdateAsync(id, programmer);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            ProgrammerResource programmerResource = _mapper.Map<Programmer, ProgrammerResource>(result.Programmer);
            return Ok(programmerResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            ProgrammerResponse result = await _programmerService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            ProgrammerResource programmerResource = _mapper.Map<Programmer, ProgrammerResource>(result.Programmer);

            return Ok(programmerResource);
        }
    }
}
