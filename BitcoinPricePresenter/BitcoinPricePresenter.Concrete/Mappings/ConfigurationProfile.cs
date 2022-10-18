using AutoMapper;
using BitcoinPricePresenter.Abstractions.Configuration;
using BitcoinPricePresenter.Abstractions.Models.ViewModels;

namespace BitcoinPricePresenter.Concrete.Mappings
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<SourcesConfiguration, GetSourcesViewModel>()
                .ConvertUsing((src, dest) =>
              {
                  var sourcesList = new List<SourceViewModel>();
                  foreach (var key in src.Sources.Keys)
                  {
                      sourcesList.Add(new SourceViewModel { SourceName = key, SourceBaseUrl = src.Sources[key].BaseUrl });
                  }
                  dest = new GetSourcesViewModel() { Sources = sourcesList };
                  return dest;
              });
        }
    }
}
