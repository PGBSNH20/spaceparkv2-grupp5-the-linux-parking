using System.Threading.Tasks;

namespace LinuxParking.API.Domain.Repositories
{
  public interface IUnitOfWork
  {
    Task CompleteAsync();
  }
}