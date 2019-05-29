using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        /// Получение списка городов
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Возращает список городов</response>
        /// <response code="500">Ошибка при получении данных</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAsync()
        {
            var status = HttpStatusCode.OK;
            IEnumerable<City> response = new List<City>();

            try
            {
                response = await _dictService.GetCities();
            }
            catch (Exception e)
            {
                status = HttpStatusCode.InternalServerError;
            }
            

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }
    }
}
