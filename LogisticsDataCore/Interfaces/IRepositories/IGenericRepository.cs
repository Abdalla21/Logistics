
using System.Linq.Expressions;

namespace LogisticsDataCore.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void SaveUser(T User);

        T GetUser(Expression<Func<T, bool>> Match);

        public List<T> GetAll();

    }
}
