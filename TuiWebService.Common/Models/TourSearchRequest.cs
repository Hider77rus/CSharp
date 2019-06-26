using System;
using System.Collections.Generic;
using System.Text;

namespace TuiWebService.Common.Models
{
    /// <summary>
    /// Параметры поиска туров
    /// </summary>
    public class TourSearchRequest
    {
        /// <summary>
        /// Город вылета
        /// </summary>
        public int DepartureCityId { get; set; }
        /// <summary>
        /// Город тура
        /// </summary>
        public int TourCityId { get; set; }
        /// <summary>
        /// Дата начало тура
        /// </summary>
        public DateTime BegTourDate { get; set; }
        /// <summary>
        /// Кол-во ночей от
        /// </summary>
        public int NightsFrom { get; set; }
        /// <summary>
        /// Кол-во ночей до
        /// </summary>
        public int NightsTo { get; set; }
        /// <summary>
        /// Кол-во человек
        /// </summary>
        public int NumberPeople { get; set; }
        /// <summary>
        /// Параметр сортировки byPrice, byPriceDesc, byName, byDate, by DateDesc
        /// </summary>
        public SortingRules SortingRules { get; set; }
    }
}
