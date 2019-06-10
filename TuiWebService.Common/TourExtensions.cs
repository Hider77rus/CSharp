using System.Collections.Generic;
using System.Linq;
using TuiWebService.Common.Models;

namespace TuiWebService.Common
{
    public static class TourExtensions
    {
        /// <summary>
        /// Сортировка туров
        /// </summary>
        /// <param name="tours"></param>
        /// <param name="rules"></param>
        /// <returns></returns>
        public static IEnumerable<Tour> OrderBy(this IEnumerable<Tour> tours, SortingRules rules)
        {
            switch (rules)
            {
                case SortingRules.byDate:
                    return tours.OrderBy(s => s.DepartureDate);
                case SortingRules.byDateDesc:
                    return tours.OrderByDescending(s => s.DepartureDate);
                case SortingRules.byName:
                    return tours.OrderBy(s => s.Hotel.Name);
                case SortingRules.byPrice:
                    return tours.OrderBy(s => s.PricePerPerson);
                case SortingRules.byPriceDesc:
                    return tours.OrderByDescending(s => s.PricePerPerson);
                default:
                    return tours.OrderBy(s => s.DepartureDate);
            }
        }
    }
}
