using Domain.Dtos.ListDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IServices
{
    public interface IMenuService
    {
        /// <summary>
        /// Metodo que obtiene todos los menus
        /// </summary>
        /// <returns></returns>
        List<SelectListItemDto> GetAllMenusSelectList();
    }
}
