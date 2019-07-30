using ProjectsManagement.API.Domain.Models;
using ProjectsManagement.API.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectsManagement.API.Domain.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> ListAsync();
        Task<Project> GetOneAsync(int id);
        Task<ProjectResponse> SaveAsync(Project project);
        Task<ProjectResponse> UpdateAsync(int id, Project project);
        Task<ProjectResponse> DeleteAsync(int id);
    }
}
