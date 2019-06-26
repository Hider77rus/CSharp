using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TuiWebService.Common;
using TuiWebService.Common.Models;
using TuiWebService.ToursAggregator;

namespace TuiWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {

        private readonly ISearchServiceAggregator _searchService;
        private readonly IMapper _mapper;
        public TourController(ISearchServiceAggregator searchService, IMapper mapper)
        {
            _searchService = searchService;
            _mapper = mapper;

        }

        /// <summary>
        /// Поиск туров
        /// </summary>
        /// <param name="tourRequest">Параметры поиска</param>
        /// <returns></returns>
        /// <response code="200">Возращает список туров</response>
        /// <response code="400">Невалидные параметры поиска</response>
        /// <response code="500">Ошибка при получении данных</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAsync(TourSearchRequest tourRequest)
        {
            var status = HttpStatusCode.OK;
            IEnumerable<Tour> response = new List<Tour>();

            if (tourRequest.BegTourDate < DateTime.Now ||
                tourRequest.NightsFrom > tourRequest.NightsTo ||
                tourRequest.NumberPeople < 1)
            {
                return BadRequest();
            }

            try
            {
                var priceOffers = await _searchService.GetTours(tourRequest);

                //Подсчитываем цену за тур на запрошенное кол-во людей.
                response = priceOffers.Select(offer => 
                    _mapper.Map<TourPriceOffer, Tour>(offer,
                        opt => opt.AfterMap((src, dest) =>
                        {
                            dest.Price = src.PricePerPerson * tourRequest.NumberPeople;
                            dest.PeopleCount = tourRequest.NumberPeople;
                        })));
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
