
using System.Linq.Expressions;

namespace LogisticsDataCore.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Save(T entity);

        T Get(Expression<Func<T, bool>> Match);

        List<T> GetAll();

        void Delete(Expression<Func<T, bool>> Match);
    }
}
