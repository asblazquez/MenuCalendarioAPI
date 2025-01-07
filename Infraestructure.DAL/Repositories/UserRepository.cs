using Domain.Entities;
using Infraestructure.DAL.Context;
using Infraestructure.DAL.IRepositories;
using Infraestructure.DAL.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BDContext context) : base(context)
        {
        }

        /// <summary>
        /// <see cref="IUserRepository.LogIn(string, string)"/>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public (int? userId, string userEmail) LogIn(string user, string password)
        {
            var userEntity = Context.Users.FirstOrDefault(x => x.Email == user && x.Password == password);

            return userEntity != null ? (userEntity?.Id, userEntity.Email) : (null, null);
        }
    }
}
