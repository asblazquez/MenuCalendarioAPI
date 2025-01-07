using Application.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using TemplateAPI.Controllers.Base;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : BaseController
    {
        private ILogInService _logInService;

        /// <summary>
        /// Cto()
        /// </summary>
        public LogInController(ILogInService logInService)
        {
            _logInService = logInService;
        }

        /// <summary>
        /// Metodo que logea un usuario
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="password">Pasword</param>
        /// <returns></returns>
        [HttpGet("LogIn")]
        public IActionResult LogIn(string user, string password)
        {
            return Ok(_logInService.LogIn(user, password));
        }
    }
}
