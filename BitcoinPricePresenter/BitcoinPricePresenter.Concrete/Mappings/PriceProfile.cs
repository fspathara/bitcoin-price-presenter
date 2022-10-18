﻿using AutoMapper;
using BitcoinPricePresenter.Abstractions;
using BitcoinPricePresenter.Abstractions.Constants;
using BitcoinPricePresenter.Abstractions.Models.Dtos;
using BitcoinPricePresenter.Abstractions.Models.ViewModels;

namespace BitcoinPricePresenter.Concrete.Mappings
{
    public class PriceProfile : Profile
    {
        public PriceProfile()
        {
            CreateMap<BitfinexPriceModel, PriceModel>(MemberList.Destination)
                .ForMember(d => d.Price, options => options.MapFrom(s => s.Price))
                .ForMember(d => d.Timestamp, options => options.MapFrom(s => (long)s.Timestamp));

            CreateMap<BitstampPriceModel, PriceModel>(MemberList.Destination)
                .ForMember(d => d.Price, options => options.MapFrom(s => s.Price))
                .ForMember(d => d.Timestamp, options => options.MapFrom(s => s.Timestamp));

            CreateMap<PriceModel, PriceViewModel>(MemberList.Destination)
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
                }));
        }
    }
}
