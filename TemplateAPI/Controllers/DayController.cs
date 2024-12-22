using Application.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TemplateAPI.Controllers.Base;

namespace Presentation.API.Controllers
{
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
        [HttpGet]
        public IActionResult GetAllDays()
        {
            return Ok(_dayService.GetAllDays());
        }
    }
}
