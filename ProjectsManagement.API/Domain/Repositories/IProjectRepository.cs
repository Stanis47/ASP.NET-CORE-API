using ProjectsManagement.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectsManagement.API.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> ListAsync();
        Task<Project> FindByIdAsync(int id);
        Task AddAsync(Project project);
        void Update(Project project);
        void Remove(Project project);
    }
}
