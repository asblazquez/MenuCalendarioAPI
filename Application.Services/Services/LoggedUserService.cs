using Application.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Application.Services.Services
{
    public class LoggedUserService : ILoggedUserService
    {
        private static LoggedUser _loggedUser;

        public static LoggedUser Instance
        {
            get
            {
                return _loggedUser ??= new LoggedUser();
            }
        }

        public static void SetUser(LoggedUser newUser)
        {
            _loggedUser = newUser;
        }
    }
}
