using LogisticsDataCore.Interfaces.IRepositories;
using LogisticsDataCore.Interfaces.IUnitOfWork;
using LogisticsDataCore.Models;
using LogisticsEntity.DBContext;
using LogisticsEntity.Repositories;

namespace LogisticsEntity.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _dbContext;

        public UnitOfWork(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;

            Categories = new GenericRepository<Category>(_dbContext);
            Governorates = new GenericRepository<Governorate>(_dbContext);
            Roles = new GenericRepository<Role>(_dbContext);
            Stores = new GenericRepository<Store>(_dbContext);
            Users = new GenericRepository<User>(_dbContext);
        }

        public IGenericRepository<Category> Categories { get; private set; }

        public IGenericRepository<Governorate> Governorates { get; private set; }

        public IGenericRepository<Role> Roles { get; private set; }

        public IGenericRepository<Store> Stores { get; private set; }

        public IGenericRepository<User> Users { get; private set; }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
