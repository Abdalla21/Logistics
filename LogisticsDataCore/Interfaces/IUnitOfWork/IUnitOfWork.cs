using LogisticsDataCore.Interfaces.IRepositories;
using LogisticsDataCore.Models;

namespace LogisticsDataCore.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Category> Categories { get; }

        IGenericRepository<Governorate> Governorates { get; }

        IGenericRepository<Role> Roles { get; }

        IGenericRepository<Store> Stores { get; }

        IGenericRepository<User> Users { get; }

        public int Complete();

    }
}
