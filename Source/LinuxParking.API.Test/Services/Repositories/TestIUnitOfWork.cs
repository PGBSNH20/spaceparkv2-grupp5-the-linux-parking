using System.Threading.Tasks;
using LinuxParking.API.Domain.Repositories;

namespace LinuxParking.API.Test.Services.Repositories
{
    public class TestIUnitOfWork : IUnitOfWork
    {
        public Task CompleteAsync()
        {
            return Task.CompletedTask;
        }
    }
}