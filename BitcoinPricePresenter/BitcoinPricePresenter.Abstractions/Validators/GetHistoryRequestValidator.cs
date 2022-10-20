using BitcoinPricePresenter.Abstractions.Extensions;
using BitcoinPricePresenter.Abstractions.Models.Requests;
using FluentValidation;

namespace BitcoinPricePresenter.Abstractions.Validators
{
    public class GetHistoryRequestValidator: AbstractValidator<GetHistoryRequest>
    {
        public GetHistoryRequestValidator()
        {
            RuleFor(s => s.DateRange)
                .NotNull()
                .Must(s => s.IsValid())
                .WithMessage(r => $"{nameof(r.DateRange.DateTo)} must be later from {nameof(r.DateRange.DateFrom)}");
        }
    }
}
