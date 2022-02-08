using CurrencyRate.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CurrencyRate.Api.Controllers
{
    [ApiController]
    [Route("api/currencyrate")]
    public class CurrencyRateController : ControllerBase
    {
        private readonly ICurrencyRateService _currencyRateService;
        private readonly ILogger<CurrencyRateController> _logger;

        public CurrencyRateController(ICurrencyRateService currencyRateService,  ILogger<CurrencyRateController> logger)
        {
            _currencyRateService = currencyRateService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrencyRates([FromQuery] string code ,CancellationToken cancellationToken)
        {
            var currencyRateList = await _currencyRateService.GetCurrencyRatesAsync(code, cancellationToken);

            return Ok(currencyRateList);
        }
    }
}
