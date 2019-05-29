using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuiWebService.Common;
using TuiWebService.Common.Models;

namespace TuiWebService.TuiProvider
{
    public class DictService : IDictService
    {

        private readonly IList<City> _cities = new List<City>();
        private readonly IList<Country> _countries = new List<Country>();
        private readonly IList<City> _departureCities = new List<City>();
        private readonly Dictionary<int, Hotel> _hotels = new Dictionary<int, Hotel>();

        public DictService()
        {
            GenerateData();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<City>> GetCities()
        {
            await Task.Yield();
            return _cities;

        }

        /// <inheritdoc />
        public async Task<IEnumerable<Country>> GetCountries()
        {
            await Task.Yield();
            return _countries;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<City>> GetDepartureCities()
        {
            await Task.Yield();
            return _departureCities;
        }

        /// <inheritdoc />
        public async Task<Hotel> GetHotel(int id)
        {
            await Task.Yield();
            return _hotels[id];
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            await Task.Yield();
            return _hotels.Values;
        }

        private void GenerateData()
        {
            GenerateCountries();
            GenerateCities();
            GenerateDepartureCities();
            GenerateHotels();
        }

        private void GenerateCountries()
        {
            int cnt = 1;
            while (cnt <= 2)
            {
                var country = new Country
                {
                    Id = cnt,
                    Name = $"Страна №{cnt}"
                };

                _countries.Add(country);
                cnt++;
            }
        }

        private void GenerateCities()
        {
            int cnt = 1;
            while (cnt <= 10)
            {
                var rndIx = new Random().Next(_countries.Count);

                var city = new City
                {
                    Id = cnt,
                    Name = $"Город №{cnt}",
                    Country = _countries[rndIx]
                };

                _cities.Add(city);
                cnt++;
            }
        }

        private void GenerateDepartureCities()
        {
            int cnt = 1;
            while (cnt <= 10)
            {
                var rndIx = new Random().Next(_countries.Count);

                var city = new City
                {
                    Id = cnt,
                    Name = $"Город вылета №{cnt}",
                    Country = _countries[rndIx]
                };

                _departureCities.Add(city);
                cnt++;
            }
        }

        private void GenerateHotels()
        {
            int cnt = 1;
            var rnd = new Random();
            while (cnt <= 500)
            {
                int start = 1995;
                int range = DateTime.Today.Year - start;

                var hotel = new Hotel
                {
                    Id = cnt,
                    Address = $"Адрес отеля {cnt}",
                    BuildYear = start + rnd.Next(range),
                    Name = $"Отель №{cnt}",
                    City = _cities[rnd.Next(_cities.Count)]
                };

                _hotels.Add(hotel.Id,hotel);
                cnt++;
            }
        }
    }
}
