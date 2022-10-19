using AutoMapper;
using BitcoinPricePresenter.Abstractions;
using BitcoinPricePresenter.Abstractions.Constants;
using BitcoinPricePresenter.Abstractions.Models.DbModels;
using BitcoinPricePresenter.Abstractions.Models.Dtos;
using BitcoinPricePresenter.Abstractions.Models.ViewModels;
using System.Globalization;

namespace BitcoinPricePresenter.Concrete.Mappings
{
    public class PriceProfile : Profile
    {
        public PriceProfile()
        {
            CreateMap<BitfinexPriceModel, PriceModel>(MemberList.Destination)
                .ForMember(d => d.Price, options => options.MapFrom(s => decimal.Parse(s.Price, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.InvariantCulture)))
                .ForMember(d => d.Timestamp, options => options.MapFrom(s => s.Timestamp.ToTimestamp()));

            CreateMap<BitstampPriceModel, PriceModel>(MemberList.Destination)
                .ForMember(d => d.Price, options => options.MapFrom(s => decimal.Parse(s.Price, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.InvariantCulture)))
                .ForMember(d => d.Timestamp, options => options.MapFrom(s => long.Parse(s.Timestamp)));

            CreateMap<PriceModel, PriceDbModel>(MemberList.Destination)
                .ForMember(d => d.Price, options => options.MapFrom(s => s.Price))
                .ForMember(d => d.Timestamp, options => options.MapFrom(s => s.Timestamp.FromUnixTimestamp()))
                .ForMember(d => d.Source, options => options.MapFrom((s, _, _, cont) =>
                {
                    if (!cont.Items.ContainsKey(Constants.Mapping.Source))
                    {
                        throw new InvalidOperationException($"Cannot convert {nameof(PriceModel)} => {nameof(PriceViewModel)} without {Constants.Mapping.Source} context variable");
                    }
                    var stringValue = cont.Items[Constants.Mapping.Source].ToString();

                    if (!Enum.TryParse(typeof(SourceEnum), stringValue, out var parsedValue))
                    {
                        throw new InvalidCastException($"Cannot parse {stringValue} to {nameof(SourceEnum)}");
                    }
                    return parsedValue;
                })); ;

            CreateMap<PriceDbModel, PriceViewModel>(MemberList.Destination)
                .ForMember(d => d.Id, options => options.MapFrom(s => s.Id))
                .ForMember(d => d.Price, options => options.MapFrom(s => s.Price))
                .ForMember(d => d.Timestamp, options => options.MapFrom(s => s.Timestamp))
                .ForMember(d => d.Source, options => options.MapFrom(s => s.Source));
        }
    }
}
