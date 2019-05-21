using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TuiWebService.Common;
using TuiWebService.Common.Models;

namespace TuiWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {

        private readonly ISearchService _searchService;
        public TourController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        /// <summary>
        /// Поиск туров
        /// </summary>
        /// <param name="departureCityId"></param>
        /// <param name="tourCityId"></param>
        /// <param name="begTourTime"></param>
        /// <param name="nightsFrom"></param>
        /// <param name="nightsTo"></param>
        /// <param name="numberPeople"></param>
        /// <param name="sortingRules">параметр сортировки byPrice, byPriceDesc, byName, byDate, by DateDesc</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Tour>> GetAsync(int departureCityId, int tourCityId, DateTime begTourTime, int nightsFrom,
            int nightsTo, int numberPeople, SortinRules sortingRules)
        {
            return await _searchService.GetTours(departureCityId, tourCityId, begTourTime, nightsFrom, nightsTo, numberPeople,
                sortingRules);

        }

    }
}
