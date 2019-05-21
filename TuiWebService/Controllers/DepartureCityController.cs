using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TuiWebService.Common;
using TuiWebService.Common.Models;

namespace TuiWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartureCityController : ControllerBase
    {

        private readonly IDictService _dictService;
        public DepartureCityController(IDictService dictService)
        {
            _dictService = dictService;
        }

        /// <summary>
        /// Получение городов вылета
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<City>> GetAsync()
        {
            return await _dictService.GetDepartureCities();
        }

    }
}
