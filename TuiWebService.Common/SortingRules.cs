using System;
using System.Collections.Generic;
using System.Text;

namespace TuiWebService.Common
{
    /// <summary>
    /// Правила сортировки
    /// </summary>
    public enum SortingRules
    {
        /// <summary>
        /// По возрастанию цены
        /// </summary>
        byPrice = 0,
        /// <summary>
        /// По убыванию цены
        /// </summary>
        byPriceDesc = 1,
        /// <summary>
        /// По имени
        /// </summary>
        byName = 2,
        /// <summary>
        /// По возрастанию даты
        /// </summary>
        byDate = 3,
        /// <summary>
        /// По убыванию даты
        /// </summary>
        byDateDesc = 4
    } 
}
