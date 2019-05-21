using System;
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
        private IList<Tour> _tours = new List<Tour>();
        private IDictService _dictService;

        private Random rnd = new Random();

        public SearchService(IDictService dictService)
        {
            _dictService = dictService;
            GenerateTours();
        }

        public async Task<IList<Tour>> GetTours(int departureCityId, int tourCityId, DateTime begTourDate,
            int nightsFrom,
            int nightsTo,
            int numberPeople, SortinRules sortinRules)
        {

            var task = new Task<IList<Tour>>(() =>
                    _tours.Where(w => w.DepartureCity.Id == departureCityId &&
                                      w.Hotel.City.Id == tourCityId &&
                                      w.DepartureDate == begTourDate &&
                                      w.Nights >= nightsFrom &&
                                      w.Nights <= nightsTo &&
                                      w.MaxRoomPeople >= numberPeople
                        )
                        .Take(1000)
                        .OrderBy(sortinRules)
                        .ToList());

            task.Start();
            return await task;
        }

        private void GenerateTours()
        {
            var departureCities = _dictService.GetDepartureCities().Result;
            var hotels = _dictService.GetHotels().Result;

            int cnt = 1;
            while (cnt <= 1000000)
            {
                var arrDate = RandomDay();
                var nights = rnd.Next(3, 16);

                var tour = new Tour()
                {
                    Airline = "AsurAir",
                    ArrivalDate = arrDate.AddDays(nights),
                    CheckInDate = arrDate.AddDays(rnd.Next(2)),
                    DepartureCity = departureCities[rnd.Next(departureCities.Count)],
                    DepartureDate = arrDate,
                    Hotel = hotels[rnd.Next(hotels.Count)],
                    MaxRoomPeople = rnd.Next(1, 6),
                    Nights = nights,
                    PricePerPerson = rnd.Next(100, 1000),
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
            return start.AddDays(rnd.Next(range));
        }
    }
}
