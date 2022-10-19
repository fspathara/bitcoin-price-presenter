using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinPricePresenter.Abstractions.Models.Requests
{
    public class GetHistoryRequest
    {
        public DateRange DateRange { get; set; } = new();

        public int MaxItems { get; set; } = 10;

        public int Page { get; set; } = 1;
    }
}
