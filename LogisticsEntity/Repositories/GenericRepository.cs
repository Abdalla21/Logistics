using LogisticsDataCore.Repositories;
using LogisticsEntity.DBContext;
using System.Linq.Expressions;

namespace LogisticsEntity.Repositories
{
    public class GenericRepository<T>(ApplicationDBContext applicationDBContext) : IGenericRepository<T> where T : class
    {
        public T GetUser(Expression<Func<T, bool>> Match) => applicationDBContext.Set<T>().FirstOrDefault(Match);

        public List<T> GetAll() => applicationDBContext.Set<T>().ToList();

        public void SaveUser(T User)
        {
            applicationDBContext.Set<T>().Add(User);
            applicationDBContext.SaveChanges();
        }
    }
}
