using AutoMapper;
using BitcoinPricePresenter.Abstractions.Constants;
using BitcoinPricePresenter.Abstractions.Models.DbModels;
using BitcoinPricePresenter.Abstractions.Models.ViewModels;
using BitcoinPricePresenter.Abstractions.Services;
using BitcoinPricePresenter.Data.Abstractions.Repositories;

namespace BitcoinPricePresenter.Concrete.Services
{
    public class BitcoinPriceService : IBitcoinPriceService
    {
        private readonly IBitcoinPriceProviderFactory _providerFactory;
        private readonly IPricesRepository _priceRepository;
        private readonly IMapper _mapper;

        public BitcoinPriceService(
            IBitcoinPriceProviderFactory providerFactory,
            IMapper mapper,
            IPricesRepository priceRepository)
        {
            _providerFactory = providerFactory;
            _mapper = mapper;
            _priceRepository = priceRepository;
        }

        public async Task<PriceViewModel> GetCurrentPriceFromSourceAsync(SourceEnum source)
        {
            var provider = _providerFactory.GetForSource(source);
            var price = await provider.GetCurrentPriceAsync();
            var priceModel = _mapper.Map<PriceDbModel>(price);
            await _priceRepository.InsertPriceAsync(priceModel);
            return _mapper.Map<PriceViewModel>(price, opts => opts.Items[Constants.Mapping.Source] = source);
        }
    }
}
