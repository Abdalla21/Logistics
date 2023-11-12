using LogisticsDataCore.Interfaces.IRepositories;
using LogisticsEntity.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LogisticsEntity.Repositories
{
    public class GenericRepository<T>(ApplicationDBContext context) : IGenericRepository<T> where T : class
    {
        public void DeleteSingle(Expression<Func<T, bool>> Match)
        {
            T entity = GetSingle(Match);
            context.Set<T>().Remove(entity);
        }

        public async Task<int> DeleteAll()
        {
            int count = await context.Set<T>().ExecuteDeleteAsync();
            return count;
        }

        public T GetSingle(Expression<Func<T, bool>> Match) => context.Set<T>().FirstOrDefault(Match);

        public List<T> GetAll() => context.Set<T>().ToList();

        public void Save(T entity) => context.Set<T>().Add(entity);

        public List<T> GetManyWhere(Expression<Func<T, bool>> Match) => context.Set<T>().Where(Match).ToList();


    }
}
