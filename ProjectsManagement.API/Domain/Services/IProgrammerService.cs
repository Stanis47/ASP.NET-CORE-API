using ProjectsManagement.API.Domain.Models;
using ProjectsManagement.API.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectsManagement.API.Domain.Services
{
    public interface IProgrammerService
    {
        Task<IEnumerable<Programmer>> ListAsync();
        Task<Programmer> GetOneAsync(int id);
        Task<ProgrammerResponse> SaveAsync(Programmer programmer);
        Task<ProgrammerResponse> UpdateAsync(int id, Programmer programmer);
        Task<ProgrammerResponse> DeleteAsync(int id);
    }
}
