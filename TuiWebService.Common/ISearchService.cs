using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TuiWebService.Common.Models;

namespace TuiWebService.Common
{
    /// <summary>
    /// Поиск туров
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// Получение туров
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<TourPriceOffer>> GetTours(TourSearchRequest request);

    }
}
