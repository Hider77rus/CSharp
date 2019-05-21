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

        private IList<City> _cities = new List<City>();
        private IList<Country> _countries = new List<Country>();
        private IList<City> _departureCities = new List<City>();
        private Dictionary<int, Hotel> _hotels = new Dictionary<int, Hotel>();

        public DictService()
        {
            GenerateData();
        }

        /// <inheritdoc />
        public async Task<IList<City>> GetCities()
        {
            var task = new Task<IList<City>>(() => _cities);
            task.Start();
            return await task;
        }

        /// <inheritdoc />
        public async Task<IList<Country>> GetCountries()
        {
            var task = new Task<IList<Country>>(() => _countries);
            task.Start();
            return await task;
        }

        /// <inheritdoc />
        public async Task<IList<City>> GetDepartureCities()
        {
            var task = new Task<IList<City>>(() => _departureCities);
            task.Start();
            return await task;
        }

        /// <inheritdoc />
        public async Task<Hotel> GetHotel(int id)
        {
            var task = new Task<Hotel>(() => _hotels[id]);
            task.Start();
            return await task;
        }

        /// <inheritdoc />
        public async Task<IList<Hotel>> GetHotels()
        {
            var task = new Task<IList<Hotel>>(() => _hotels.Values.ToList());
            task.Start();
            return await task;
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
            while (cnt <= 500)
            {
                var rnd = new Random();
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;

                var hotel = new Hotel
                {
                    Id = cnt,
                    Address = $"Адрес отеля {cnt}",
                    BuildDate = start.AddDays(rnd.Next(range)),
                    Name = $"Отель №{cnt}",
                    City = _cities[rnd.Next(_cities.Count)]
                };

                _hotels.Add(hotel.Id,hotel);
                cnt++;
            }
        }
    }
}
