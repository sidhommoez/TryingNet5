using System;
using System.Threading.Tasks;
using TryingNet5.data;

namespace TryingNet5.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> Hotels { get; }
        Task Save();
    }
}
