using AutoMapper;
using BitcoinPricePresenter.Abstractions.Models.ViewModels;
using BitcoinPricePresenter.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace BitcoinPricePresenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitcoinPriceController : ControllerBase
    {
        private readonly ISourcesConfigurationService _sourcesConfigurationService;
        private readonly IMapper _mapper;

        public BitcoinPriceController(ISourcesConfigurationService sourcesConfigurationService, IMapper mapper)
        {
            _sourcesConfigurationService = sourcesConfigurationService;
            _mapper = mapper;
        }

        [HttpGet("GetSources")]
        [ProducesResponseType(typeof(GetSourcesViewModel), StatusCodes.Status200OK)]
        public IActionResult GetSources()
        {
            var configuration = _sourcesConfigurationService.GetAll();
            var response = _mapper.Map<GetSourcesViewModel>(configuration);
            return Ok(response);
        }
    }
}
