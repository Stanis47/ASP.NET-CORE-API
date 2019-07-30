using ProjectsManagement.API.Domain.Repositories;
using ProjectsManagement.API.Persistance.Contexts;
using System.Threading.Tasks;

namespace ProjectsManagement.API.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
