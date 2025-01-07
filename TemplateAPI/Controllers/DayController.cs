using Application.Services.IServices;
using Domain.Searchs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TemplateAPI.Controllers.Base;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayController : BaseController
    {
        private IDayService _dayService;

        /// <summary>
        /// Cto()
        /// </summary>
        public DayController(IDayService dayService)
        {
            _dayService = dayService;
        }

        /// <summary>
        /// Metodo que obtiene todos los dias con sus menus
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllDays")]
        public IActionResult GetAllDays()
        {
            return Ok(_dayService.GetAllDays());
        }

        /// <summary>
        /// Metodo que obtiene todos los dias con sus menus de un periodo
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDaysByPeriod")]
        public IActionResult GetDaysByPeriod([FromQuery] DaysByPeriodSerach search)
        {
            return Ok(_dayService.GetDaysByPeriod(search));
        }
    }
}
