
using System.Linq.Expressions;

namespace LogisticsDataCore.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Save(T User);

        T Get(Expression<Func<T, bool>> Match);

        public List<T> GetAll();

    }
}
