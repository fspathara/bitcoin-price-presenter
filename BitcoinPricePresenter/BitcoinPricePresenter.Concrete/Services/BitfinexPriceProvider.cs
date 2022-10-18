using AutoMapper;
using BitcoinPricePresenter.Abstractions.Models.Dtos;
using BitcoinPricePresenter.Abstractions.Services;

namespace BitcoinPricePresenter.Concrete.Services
{
    public class BitfinexPriceProvider : IBitcoinPriceProvider
    {
        private readonly IBitfinexClient _bitfinexClient;
        private readonly IMapper _mapper;

        public BitfinexPriceProvider(IBitfinexClient bitfinexClient, IMapper mapper)
        {
            _bitfinexClient = bitfinexClient;
            _mapper = mapper;
        }

        public async Task<PriceModel> GetCurrentPriceAsync()
        {
            var price = await _bitfinexClient.GetCurrentPriceAsync();
            return _mapper.Map<PriceModel>(price);
        }
    }
}
