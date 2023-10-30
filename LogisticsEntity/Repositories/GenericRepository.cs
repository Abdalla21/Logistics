using LogisticsDataCore.Interfaces.IRepositories;
using LogisticsEntity.DBContext;
using System.Linq.Expressions;

namespace LogisticsEntity.Repositories
{
    public class GenericRepository<T>(ApplicationDBContext context) : IGenericRepository<T> where T : class
    {
        public void Delete(Expression<Func<T, bool>> Match)
        {
            T entity = Get(Match);
            context.Set<T>().Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> Match) => context.Set<T>().FirstOrDefault(Match);

        public List<T> GetAll() => context.Set<T>().ToList();

        public void Save(T entity) => context.Set<T>().Add(entity);

    }
}
