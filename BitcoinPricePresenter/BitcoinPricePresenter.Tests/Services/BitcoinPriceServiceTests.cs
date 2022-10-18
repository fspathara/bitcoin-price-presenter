using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using AutoMapper;
using BitcoinPricePresenter.Abstractions.Models.DbModels;
using BitcoinPricePresenter.Abstractions.Models.Dtos;
using BitcoinPricePresenter.Abstractions.Models.ViewModels;
using BitcoinPricePresenter.Abstractions.Services;
using BitcoinPricePresenter.Concrete.Services;
using BitcoinPricePresenter.Data.Abstractions.Repositories;
using BitcoinPricePresenter.Tests.Extensions;
using Moq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace BitcoinPricePresenter.Tests.Services
{
    public class BitcoinPriceServiceTests
    {
        [Theory]
        [AutoMoqData]
        public async Task GetCurrentPriceFromSourceAsync_WhenCalled_CallFactoryGetPriceStoreAndMapToReturn(
            [Frozen] Mock<IBitcoinPriceProvider> priceProvider,
            [Frozen] Mock<IBitcoinPriceProviderFactory> bitcoinPriceProviderFactory,
            [Frozen] Mock<IPricesRepository> priceRepository,
            [Frozen] Mock<IMapper> mapper,
            BitcoinPriceService sut)
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            Expression<Func<IBitcoinPriceProvider, Task<PriceModel>>> priceExpression = s => s.GetCurrentPriceAsync();
            priceProvider.Setup(priceExpression)
                .ReturnsUsingFixture(fixture);

            Expression<Func<IBitcoinPriceProviderFactory, IBitcoinPriceProvider>> factoryExpression = s => s.GetForSource(It.IsAny<SourceEnum>());
            bitcoinPriceProviderFactory.Setup(factoryExpression)
                .Returns(priceProvider.Object);

            Expression<Func<IPricesRepository, Task>> insertExpression = s => s.InsertPriceAsync(It.IsAny<PriceDbModel>());
            priceRepository.Setup(insertExpression)
                           .Returns(Task.CompletedTask);

            Expression<Func<IMapper, PriceDbModel>> dbModelMappingExpression = s => s.Map<PriceDbModel>(It.IsAny<PriceModel>());
            Expression<Func<IMapper, PriceViewModel>> viewModelMappingExpression = s => s.Map<PriceViewModel>(It.IsAny<PriceModel>(), It.IsAny<Action<IMappingOperationOptions<object, PriceViewModel>>>());

            mapper.Setup(dbModelMappingExpression)
                .ReturnsUsingFixture(fixture);
            mapper.Setup(viewModelMappingExpression)
                .ReturnsUsingFixture(fixture);

            await sut.GetCurrentPriceFromSourceAsync(It.IsAny<SourceEnum>());

            bitcoinPriceProviderFactory.Verify(factoryExpression, Times.Once);

            priceProvider.Verify(priceExpression, Times.Once);

            priceRepository.Verify(insertExpression, Times.Once);


            mapper.Verify(dbModelMappingExpression, Times.Once);
            mapper.Verify(viewModelMappingExpression, Times.Once);
        }
    }
}
