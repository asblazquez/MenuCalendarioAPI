using Domain.Dtos.ListDto;
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
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(BDContext context) : base(context)
        {
        }

        /// <summary>
        /// <see cref="IMenuRepository.GetAllMenusSelectList"/>"/>
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public List<SelectListItemDto> GetAllMenusSelectList(int idUser)
        {
            return Context.Menus
                .Where(x => x.IdUser == idUser)
                .Select(x => new SelectListItemDto
                {
                    Value = x.Id,
                    Text = x.Title
                }).ToList();
        }
    }
}
