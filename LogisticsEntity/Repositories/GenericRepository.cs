using LogisticsDataCore.Interfaces.IRepositories;
using LogisticsEntity.DBContext;
using System.Linq.Expressions;

namespace LogisticsEntity.Repositories
{
    public class GenericRepository<T>(ApplicationDBContext applicationDBContext) : IGenericRepository<T> where T : class
    {
        public T Get(Expression<Func<T, bool>> Match) => applicationDBContext.Set<T>().FirstOrDefault(Match);

        public List<T> GetAll() => applicationDBContext.Set<T>().ToList();

        public void Save(T User)
        {
            applicationDBContext.Set<T>().Add(User);
        }
    }
}
