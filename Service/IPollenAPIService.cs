using System.Threading.Tasks;

namespace Gruppe1.Service
{
    public interface IPollenAPIService
    {
        Task<string> GetPollenForecastAsync();
    }
}