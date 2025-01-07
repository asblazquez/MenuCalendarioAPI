using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IServices
{
    public interface ILogInService
    {
        /// <summary>
        /// LogIn Method
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="password">PassWord</param>
        /// <returns></returns>
        bool LogIn(string user, string password);
    }
}
