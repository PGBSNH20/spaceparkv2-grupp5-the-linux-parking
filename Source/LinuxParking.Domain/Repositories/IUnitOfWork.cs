using System.Threading.Tasks;

namespace LinuxParking.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}