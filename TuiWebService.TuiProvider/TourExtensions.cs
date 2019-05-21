using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TuiWebService.Common;
using TuiWebService.Common.Models;

namespace TuiWebService.TuiProvider
{
    static class TourExtensions
    {
        /// <summary>
        /// Сортировка туров
        /// </summary>
        /// <param name="tours"></param>
        /// <param name="rules"></param>
        /// <returns></returns>
        public static IEnumerable<Tour> OrderBy(this IEnumerable<Tour> tours, SortinRules rules)
        {
            switch (rules)
            {
                case SortinRules.byDate:
                    return tours.OrderBy(s => s.DepartureDate);
                case SortinRules.byDateDesc:
                    return tours.OrderByDescending(s => s.DepartureDate );
                case SortinRules.byName:
                    return tours.OrderBy(s => s.Hotel.Name);
                case SortinRules.byPrice:
                    return tours.OrderBy(s => s.PricePerPerson);
                case SortinRules.byPriceDesc:
                    return tours.OrderByDescending(s => s.PricePerPerson);
                default:
                    return tours.OrderBy(s => s.DepartureDate);
            }
        }
    }
}
