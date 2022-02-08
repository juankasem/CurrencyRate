using CurrencyRate.Domain.Interfaces;
using CurrencyRate.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyRate.Service
{
    public class CurrencyRateService : ICurrencyRateService
    {
        public async Task<CurrencyRateData> GetCurrencyRatesAsync(string code, CancellationToken cancellationToken)
        {
            var url = $"http://www.floatrates.com/daily/{code}.json";

            var httpClient = new HttpClient();

            try
            {
                var httpResponse = await httpClient.GetAsync(url, cancellationToken);

                var responseContent = await httpResponse.Content.ReadAsStringAsync(cancellationToken);

                var data = JsonConvert.DeserializeObject<CurrencyRateResponse>(responseContent);

                return data.Data;

            }
            catch (Exception ex)
            {  
                throw;
            }
        }
    }
}
