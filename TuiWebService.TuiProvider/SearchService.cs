using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiWebService.Common;
using TuiWebService.Common.Models;

namespace TuiWebService.TuiProvider
{
    public class SearchService : ISearchService
    {
        private readonly IList<Tour> _tours = new List<Tour>();
        private readonly IDictService _dictService;

        private readonly Random _rnd = new Random();

        public SearchService(IDictService dictService)
        {
            _dictService = dictService;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Tour>> GetTours(int departureCityId, int tourCityId, DateTime begTourDate,
            int nightsFrom,
            int nightsTo,
            int numberPeople, SortinRules sortingRules)
        {

            if (_tours.Count == 0)
                await GenerateTours();

            return _tours.Where(w => w.DepartureCity.Id == departureCityId &&
                                      w.Hotel.City.Id == tourCityId &&
                                      w.DepartureDate == begTourDate &&
                                      w.Nights >= nightsFrom &&
                                      w.Nights <= nightsTo &&
                                      w.MaxRoomPeople >= numberPeople
                        )
                        .OrderBy(sortingRules)
                        .Take(1000);
        }

        /// <summary>
        /// Генерируем туры
        /// </summary>
        /// <returns></returns>
        private async Task GenerateTours()
        {
            var departureCitiesEmun = await _dictService.GetDepartureCities();
            var departureCities = departureCitiesEmun.ToList();

            var hotelsEnum = await _dictService.GetHotels();
            var hotels = hotelsEnum.ToList();

            int cnt = 1;
            while (cnt <= 1000000)
            {
                var arrDate = RandomDay();
                var nights = _rnd.Next(3, 16);

                var tour = new Tour()
                {
                    Airline = "AsurAir",
                    ArrivalDate = arrDate.AddDays(nights),
                    CheckInDate = arrDate.AddDays(_rnd.Next(2)),
                    DepartureCity = departureCities[_rnd.Next(departureCities.Count)],
                    DepartureDate = arrDate,
                    Hotel = hotels[_rnd.Next(hotels.Count)],
                    MaxRoomPeople = _rnd.Next(1, 6),
                    Nights = nights,
                    PricePerPerson = _rnd.Next(100, 1000),
                    Room = "Standart"
                };
                
                _tours.Add(tour);
                cnt++;
            }
        }

        DateTime RandomDay()
        {
            DateTime start = DateTime.Today;
            int range = 10;
            return start.AddDays(_rnd.Next(range));
        }
    }
}
