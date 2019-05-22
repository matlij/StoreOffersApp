using System.Threading.Tasks;
using AppLocator.Models;

namespace AppLocator.Interfaces.Services.Data
{
    public interface ISettingsService
    {
        Task<Settings> GetSettings();
    }
}