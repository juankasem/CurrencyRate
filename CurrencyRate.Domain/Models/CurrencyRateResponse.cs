using Newtonsoft.Json;
using System;

namespace CurrencyRate.Domain.Models
{
    public class CurrencyRateResponse
    {
        [JsonProperty("eur")]
        public CurrencyRateData Data { get; set; }
    }
}



