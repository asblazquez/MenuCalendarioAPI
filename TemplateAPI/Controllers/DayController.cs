using Application.Services.IServices;
using Domain.Dtos;
using Domain.Searchs;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Presentation.API.Models;
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

        /// <summary>
        /// Metodo que agrega o edita un dia
        /// </summary>
        /// <param name="model">Modelo</param>
        /// <returns></returns>
        [HttpPost("AddEditMealDay")]
        public IActionResult AddEditMealDay(DayModel model)
        {
            _dayService.AddEditMealDay(model.Adapt<DayDto>());
            return Ok($"Comida guardada para el dia {model.Date.ToShortDateString()}");
        }

        /// <summary>
        /// Metodo que agrega o edita un dia
        /// </summary>
        /// <param name="model">Modelo</param>
        /// <returns></returns>
        [HttpPost("AddEditDinnerDay")]
        public IActionResult AddEditDinnerDay(DayModel model)
        {
            _dayService.AddEditDinnerDay(model.Adapt<DayDto>());
            return Ok($"Cena guardada para el dia {model.Date.ToShortDateString()}");
        }
    }
}
