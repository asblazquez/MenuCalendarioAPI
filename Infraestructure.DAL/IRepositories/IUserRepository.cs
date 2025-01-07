using Domain.Entities;
using Infraestructure.DAL.IRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DAL.IRepositories
{
    /// <summary>
    /// Interfaz del repositorio de usuario
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Metodo que permite loguear un usuario
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        (int? userId, string userEmail) LogIn(string user, string password);
    }
}
