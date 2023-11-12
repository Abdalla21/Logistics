
using System.Linq.Expressions;

namespace LogisticsDataCore.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Save(T entity);

        T GetSingle(Expression<Func<T, bool>> Match);

        List<T> GetManyWhere(Expression<Func<T, bool>> Match);

        List<T> GetAll();

        void DeleteSingle(Expression<Func<T, bool>> Match);

        Task<int> DeleteAll();
    }
}
