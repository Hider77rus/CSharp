using System;

namespace TuiWebService.Common.Models
{
    /// <summary>
    /// Отель
    /// </summary>
    public class Hotel
    {
        /// <summary>
        /// Идентификатор отеля
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public City City { get; set; }

        /// <summary>
        /// Год постройки
        /// </summary>
        public DateTime BuildDate { get; set; }
    }
}
