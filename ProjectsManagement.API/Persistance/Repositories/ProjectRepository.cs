using Microsoft.EntityFrameworkCore;
using ProjectsManagement.API.Domain.Models;
using ProjectsManagement.API.Domain.Repositories;
using ProjectsManagement.API.Persistance.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectsManagement.API.Persistance.Repositories
{
    public class ProjectRepository : BaseRepository, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _context.Projects.Include(p => p.Programmers)
                                          .ThenInclude(pp => pp.Programmer)
                                          .ToListAsync();
        }

        public async Task<Project> FindByIdAsync(int id)
        {
            return await _context.Projects.Include(p => p.Programmers)
                                          .ThenInclude(pp => pp.Programmer)
                                          .FirstOrDefaultAsync(p => p.ProjectID == id);
        }

        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public void Update(Project project)
        {
            /*foreach (var item in _context.ProjectProgrammers.Where(pp => pp.ProjectID == project.ProjectID))
            {
                _context.ProjectProgrammers.Remove(item);
            }

            _context.SaveChanges();

            foreach (var item in project.Programmers)
            {
                _context.ProjectProgrammers.Add(new ProjectProgrammer
                {
                    ProjectID = project.ProjectID,
                    ProgrammerID = item.ProgrammerID
                });
            }
            */
            _context.Projects.Update(project);
        }

        public void Remove(Project project)
        {
            _context.Projects.Remove(project);
        }
    }
}
