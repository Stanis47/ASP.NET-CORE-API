using Microsoft.EntityFrameworkCore;
using ProjectsManagement.API.Domain.Models;
using ProjectsManagement.API.Domain.Repositories;
using ProjectsManagement.API.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectsManagement.API.Persistance.Repositories
{
    public class ProgrammerRepository : BaseRepository, IProgrammerRepository
    {
        public ProgrammerRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Programmer>> ListAsync()
        {
            IEnumerable<Programmer> programmers = await _context.Programmers.Include(p => p.Projects)
                                                                            .ThenInclude(pp => pp.Project)
                                                                            .ToListAsync();
            foreach (Programmer programmer in programmers)
            {
                int age = DateTime.Now.Year - programmer.BirthDate.Year;
                programmer.Age = age;
            }

            return programmers;
        }

        public async Task<Programmer> FindByIdAsync(int id)
        {
            Programmer programmer = await _context.Programmers.Include(p => p.Projects)
                                                              .ThenInclude(pp => pp.Project)
                                                              .FirstOrDefaultAsync(p => p.ProgrammerID == id);

            int age = DateTime.Now.Year - programmer.BirthDate.Year;
            programmer.Age = age;

            return programmer;
        }

        public async Task AddAsync(Programmer programmer)
        {
            await _context.Programmers.AddAsync(programmer);
        }

        public void Update(Programmer programmer)
        {
            _context.Programmers.Update(programmer);
        }

        public void Remove(Programmer programmer)
        {
            _context.Programmers.Remove(programmer);
        }
    }
}
