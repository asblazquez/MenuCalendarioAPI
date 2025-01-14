﻿using Domain.Dtos.ListDto;
using Domain.Entities;
using Infraestructure.DAL.IRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DAL.IRepositories
{
    public interface IMenuRepository : IRepository<Menu>
    {

        /// <summary>
        /// Obtiene todos los menus de un usuario
        /// </summary>
        /// <param name="idUser">Id del usuario</param>
        /// <returns></returns>
        List<SelectListItemDto> GetAllMenusSelectList(int idUser);
    }
}
