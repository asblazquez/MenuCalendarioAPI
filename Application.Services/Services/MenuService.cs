using Application.Services.IServices;
using Application.Services.Services.Base;
using Domain.Dtos.ListDto;
using Infraestructure.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Services
{
    public class MenuService : BaseService, IMenuService
    {
        public MenuService(IUnitOfWork uow) : base(uow)
        {
        }

        /// <summary>
        /// <see cref="IMenuService.GetAllMenusSelectList"/>
        /// </summary>
        /// <returns></returns>
        public List<SelectListItemDto> GetAllMenusSelectList()
        {
            return _uow.Menu.GetAllMenusSelectList(LoggedUserService.Instance.UserId);
        }
    }
}
