
namespace LogisticsDataCore.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void SaveUser(T User);

        T GetUser(int userID);

    }
}
