using AutoMapper;
using BitcoinPricePresenter.Abstractions.Models.Queries;
using BitcoinPricePresenter.Abstractions.Models.Requests;

namespace BitcoinPricePresenter.Concrete.Mappings
{
    public class QueryProfile : Profile
    {
        public QueryProfile()
        {
            CreateMap<GetHistoryRequest, PriceGetQuery>(MemberList.Destination)
                .ForMember(d => d.DateRange, options => options.MapFrom(s => s.DateRange))
                .ForMember(d => d.Limit, options => options.MapFrom(s => s.MaxItems))
                .ForMember(d => d.Page, options => options.MapFrom(s => s.Page));
        }
    }
}
