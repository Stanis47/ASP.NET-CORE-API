using ProjectsManagement.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectsManagement.API.Domain.Repositories
{
    public interface IProgrammerRepository
    {
        Task<IEnumerable<Programmer>> ListAsync();
        Task<Programmer> FindByIdAsync(int id);
        Task AddAsync(Programmer programmer);
        void Update(Programmer programmer);
        void Remove(Programmer programmer);
        
    }
}
