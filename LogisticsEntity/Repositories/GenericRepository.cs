using LogisticsDataCore.Repositories;

namespace LogisticsEntity.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public T GetUser(int userID)
        {
            throw new NotImplementedException();
        }

        public void SaveUser(T User)
        {
            
        }
    }
}
