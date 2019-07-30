using System.Threading.Tasks;

namespace ProjectsManagement.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
