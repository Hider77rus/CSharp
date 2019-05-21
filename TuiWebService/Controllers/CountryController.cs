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
    public class CountryController : ControllerBase
    {

        private readonly IDictService _dictService;
        public CountryController(IDictService dictService)
        {
            _dictService = dictService;
        }

        /// <summary>
        /// Получение списка стран
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Country>> GetAsync()
        {
            return await _dictService.GetCountries();
        }

    }
}
