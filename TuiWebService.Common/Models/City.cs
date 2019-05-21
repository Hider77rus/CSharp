namespace TuiWebService.Common.Models
{
    /// <summary>
    /// Город
    /// </summary>
    public class City
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Страна
        /// </summary>
        public Country Country { get; set; }
    }
}
