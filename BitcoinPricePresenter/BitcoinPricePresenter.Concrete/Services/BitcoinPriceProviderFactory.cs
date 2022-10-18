using BitcoinPricePresenter.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinPricePresenter.Concrete.Services
{
    public class BitcoinPriceProviderFactory : IBitcoinPriceProviderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public BitcoinPriceProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IBitcoinPriceProvider GetForSource(SourceEnum source) =>
             source switch
             {
                 SourceEnum.Bitstamp => (IBitcoinPriceProvider)_serviceProvider.GetService(typeof(BitstampPriceProvider)),
                 SourceEnum.Bitfinex => (IBitcoinPriceProvider)_serviceProvider.GetService(typeof(BitfinexPriceProvider)),
                 _ => throw new ArgumentOutOfRangeException(nameof(source)),
             };
    }
}
