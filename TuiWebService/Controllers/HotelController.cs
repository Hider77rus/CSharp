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
    public class HotelController : ControllerBase
    {
        private readonly IDictService _dictService;
        public HotelController(IDictService dictService)
        {
            _dictService = dictService;
        }

        /// <summary>
        /// Получение списка отелей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<Hotel>> GetAsync()
        {
            return await _dictService.GetHotels();
        }

    }
}
