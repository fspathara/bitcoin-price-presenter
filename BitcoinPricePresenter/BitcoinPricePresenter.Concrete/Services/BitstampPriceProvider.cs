using AutoMapper;
using BitcoinPricePresenter.Abstractions.Models.Dtos;
using BitcoinPricePresenter.Abstractions.Services;

namespace BitcoinPricePresenter.Concrete.Services
{
    public class BitstampPriceProvider : IBitcoinPriceProvider
    {
        private readonly IBitstampClient _bitstampClient;
        private readonly IMapper _mapper;

        public BitstampPriceProvider(IBitstampClient bitstampClient, IMapper mapper)
        {
            _bitstampClient = bitstampClient;
            _mapper = mapper;
        }


        public async Task<PriceModel> GetCurrentPriceAsync()
        {
            var price = await _bitstampClient.GetCurrentPriceAsync();
            return _mapper.Map<PriceModel>(price);
        }
    }
}
