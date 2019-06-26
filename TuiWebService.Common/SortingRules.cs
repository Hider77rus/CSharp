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
        ByPrice = 0,
        /// <summary>
        /// По убыванию цены
        /// </summary>
        ByPriceDesc = 1,
        /// <summary>
        /// По имени
        /// </summary>
        ByName = 2,
        /// <summary>
        /// По возрастанию даты
        /// </summary>
        ByDate = 3,
        /// <summary>
        /// По убыванию даты
        /// </summary>
        ByDateDesc = 4
    } 
}
