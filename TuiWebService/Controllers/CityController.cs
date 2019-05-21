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
    public class CityController : ControllerBase
    {

        private readonly IDictService _dictService;
        public CityController(IDictService dictService)
        {
            _dictService = dictService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<City>> GetAsync()
        {
            return await _dictService.GetCities();
        }

    }
}
