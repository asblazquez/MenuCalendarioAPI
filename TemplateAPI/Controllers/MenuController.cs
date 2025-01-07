using Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using TemplateAPI.Controllers.Base;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : BaseController
    {
        private IMenuService _menuService;

        /// <summary>
        /// Ctor()
        /// </summary>
        /// <param name="menuService"></param>
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        /// <summary>
        /// Metodo que obtiene todos los menus
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllMenusSelectList")]
        public IActionResult GetAllMenusSelectList()
        {
            return Ok(_menuService.GetAllMenusSelectList());
        }
    }
}
