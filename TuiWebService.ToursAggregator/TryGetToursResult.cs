using System;
using System.Collections.Generic;
using System.Text;
using TuiWebService.Common.Models;

namespace TuiWebService.ToursAggregator
{
    class TryGetToursResult
    {
        public bool IsTimeout { get; set; }
        public IEnumerable<Tour> Tours { get; set; }
    }
}
