using CurrencyRate.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyRate.Domain.Interfaces
{
   public interface ICurrencyRateService
    {
        Task<CurrencyRateData> GetCurrencyRatesAsync(string code, CancellationToken cancellationToken);
    }
}
