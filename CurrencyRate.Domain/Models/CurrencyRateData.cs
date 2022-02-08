using Newtonsoft.Json;
using System;

namespace CurrencyRate.Domain.Models
{
    public class CurrencyRateData
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }

        [JsonProperty("inverseRate")]
        public double InverseRate { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }

}



