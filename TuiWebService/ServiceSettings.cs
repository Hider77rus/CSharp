using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TuiWebService
{
    /// <summary>
    /// Настройки сервиса
    /// </summary>
    public class ServiceSettings
    {
        /// <summary>
        /// Timeout в миллисекундах
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Адрес, на котором крутится сервис
        /// </summary>
        public string Address { get; set; }
    }
}
