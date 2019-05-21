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
        /// <param name="departureCityId">Идентификатор города вылета</param>
        /// <param name="tourCityId">Идентификатор города тура</param>
        /// <param name="begTourDate"></param>
        /// <param name="nightsFrom">Кол-во ночей От</param>
        /// <param name="nightsTo">Кол-во ночей До</param>
        /// <param name="numberPeople">Кол-во человек</param>
        /// <param name="sortinRules">Правило сортировки</param>
        /// <returns></returns>
        Task<IList<Tour>> GetTours(int departureCityId, int tourCityId, DateTime begTourDate, int nightsFrom,
            int nightsTo,
            int numberPeople, SortinRules sortinRules);

    }
}
