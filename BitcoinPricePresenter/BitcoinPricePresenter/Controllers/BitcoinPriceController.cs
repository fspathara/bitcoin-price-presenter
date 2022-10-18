using AutoMapper;
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

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(GetSourcesViewModel), StatusCodes.Status200OK)]
        public IActionResult GetSources()
        {
            var configuration = _sourcesConfigurationService.GetAll();
            var response = _mapper.Map<GetSourcesViewModel>(configuration);
            return Ok(response);
        }

        [HttpPost("[action]/{source}")]
        [ProducesResponseType(typeof(GetSourcesViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCurrentPriceAsync(SourceEnum source)
        {
            var serviceResult = await _bitcoinPriceService.GetCurrentPriceFromSourceAsync(source);
            return Ok(serviceResult);
        }
    }
}
