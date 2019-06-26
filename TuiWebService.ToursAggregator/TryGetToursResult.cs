using System;
using System.Collections.Generic;
using System.Text;
using TuiWebService.Common.Models;

namespace TuiWebService.ToursAggregator
{
    /// <summary>
    /// Резульатат попытки получения данных у поставщика
    /// </summary>
    class TryGetToursResult
    {
        public IEnumerable<TourPriceOffer> Tours { get; set; }
        public bool HasError { get; set; }
        public Exception Exception { get; set; }
        
    }
}
