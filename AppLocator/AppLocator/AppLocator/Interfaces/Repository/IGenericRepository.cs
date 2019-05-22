using System.Threading.Tasks;

namespace AppLocator.Interfaces.Repository
{
    public interface IGenericRepository
    {
        Task<T> GetAsync<T>(string uri);
    }
}