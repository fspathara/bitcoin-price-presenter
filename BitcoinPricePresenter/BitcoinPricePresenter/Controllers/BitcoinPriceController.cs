using AutoMapper;
using BitcoinPricePresenter.Abstractions.Models.Queries;
using BitcoinPricePresenter.Abstractions.Models.Requests;
using BitcoinPricePresenter.Abstractions.Models.ViewModels;
using BitcoinPricePresenter.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace BitcoinPricePresenter.Controllers
{
    [ApiController]
    public class BitcoinPriceController : BaseController
    {
        private readonly ISourcesConfigurationService _sourcesConfigurationService;
        private readonly IMapper _mapper;
        private readonly IBitcoinPriceService _bitcoinPriceService;

        public BitcoinPriceController(
            ISourcesConfigurationService sourcesConfigurationService,
            IMapper mapper,
            IBitcoinPriceService bitcoinPriceService)
        {
            _sourcesConfigurationService = sourcesConfigurationService;
            _mapper = mapper;
            _bitcoinPriceService = bitcoinPriceService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetSourcesViewModel), StatusCodes.Status200OK)]
        public IActionResult GetSources()
        {
            var configuration = _sourcesConfigurationService.GetAll();
            var response = _mapper.Map<GetSourcesViewModel>(configuration);
            return Ok(response);
        }

        [HttpPost("{source}")]
        [ProducesResponseType(typeof(GetSourcesViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCurrentPriceAsync(SourceEnum source)
        {
            var currentPrice = await _bitcoinPriceService.GetCurrentPriceFromSourceAsync(source);
            return Ok(currentPrice);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<GetSourcesViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHistory([FromBody] GetHistoryRequest request)
        {
            var prices = await _bitcoinPriceService.GetPrices(_mapper.Map<GetPricesQuery>(request));
            return Ok(prices);
        }
    }
}
