using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TuiWebService.Common.Models;

namespace TuiWebService.Common
{
    /// <summary>
    /// Получение справочной информации
    /// </summary>
    public interface IDictService
    {
        /// <summary>
        /// Получить города
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<City>> GetCities();

        /// <summary>
        /// Получить страны
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Country>> GetCountries();

        /// <summary>
        /// Получить города вылета
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<City>> GetDepartureCities();

        /// <summary>
        /// Получить отель по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор отеля</param>
        /// <returns></returns>
        Task<Hotel> GetHotel(int id);

        /// <summary>
        /// Получение списка отелей
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Hotel>> GetHotels();
    }
}
