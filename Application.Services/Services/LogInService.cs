using Application.Services.IServices;
using Application.Services.Services.Base;
using Infraestructure.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Application.Services.Services
{
    public class LogInService : BaseService, ILogInService
    {
        public LogInService(IUnitOfWork uow) : base(uow)
        {
        }

        /// <summary>
        /// <see cref="ILogInService.LogIn"/>"/>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LogIn(string user, string password)
        {
            var userObj = _uow.User.LogIn(user, password);

            if (userObj.userId.HasValue)
            {
                LoggedUserService.SetUser(
                new()
                {
                    UserId = userObj.userId ?? 0,
                    UserEmail = userObj.userEmail
                });
                return true;
            }
            else
            {
                LoggedUserService.SetUser(new());
                return false;
            }
        }
    }
}
