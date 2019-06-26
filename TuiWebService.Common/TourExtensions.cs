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
        public static IEnumerable<TourPriceOffer> OrderBy(this IEnumerable<TourPriceOffer> tours, SortingRules rules)
        {
            switch (rules)
            {
                case SortingRules.ByDate:
                    return tours.OrderBy(s => s.DepartureDate);
                case SortingRules.ByDateDesc:
                    return tours.OrderByDescending(s => s.DepartureDate);
                case SortingRules.ByName:
                    return tours.OrderBy(s => s.Hotel.Name);
                case SortingRules.ByPrice:
                    return tours.OrderBy(s => s.PricePerPerson);
                case SortingRules.ByPriceDesc:
                    return tours.OrderByDescending(s => s.PricePerPerson);
                default:
                    return tours.OrderBy(s => s.DepartureDate);
            }
        }
    }
}
