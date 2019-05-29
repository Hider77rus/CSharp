using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        /// <param name="departureCityId">Город вылета</param>
        /// <param name="tourCityId">Город тура</param>
        /// <param name="begTourDate">Дата начало тура</param>
        /// <param name="nightsFrom">Кол-во ночей от</param>
        /// <param name="nightsTo">Кол-во ночей до</param>
        /// <param name="numberPeople">Кол-во человек</param>
        /// <param name="sortingRules">Параметр сортировки byPrice, byPriceDesc, byName, byDate, by DateDesc</param>
        /// <returns></returns>
        /// <response code="200">Возращает список туров</response>
        /// <response code="400">Невалидные параметры поиска</response>
        /// <response code="500">Ошибка при получении данных</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAsync(int departureCityId, int tourCityId, DateTime begTourDate, int nightsFrom,
            int nightsTo, int numberPeople, SortinRules sortingRules)
        {
            var status = HttpStatusCode.OK;
            IEnumerable<Tour> response = new List<Tour>();

            if (begTourDate < DateTime.Now || 
                nightsFrom > nightsTo || 
                numberPeople < 1)
            {
                return BadRequest();
            }
            

            try
            {
                response = await _searchService.GetTours(departureCityId, tourCityId, begTourDate, nightsFrom, nightsTo, numberPeople,
                    sortingRules);
            }
            catch (Exception e)
            {
                status = HttpStatusCode.InternalServerError;
            }

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };

        }

    }
}
