using Domain.Dtos.ListDto;
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
    /// Repositorio Day
    /// </summary>
    public interface IDayRepository : IRepository<Day>
    {
        /// <summary>
        /// Metodo que obtiene todos los dias
        /// </summary>
        /// <returns></returns>
        List<ListDayDto> GetAllDays();

        /// <summary>
        /// Metodo que obtiene todos los dias con sus menus de un periodo
        /// </summary>
        /// <param name="startDate">Fecha Inicio</param>
        /// <param name="endDate">Fecha Fin</param>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        List<ListDayDto> GetDaysByPeriod(DateOnly startDate, DateOnly endDate, int userId);

        /// <summary>
        /// Metodo que obtiene un dia por fecha
        /// </summary>
        /// <param name="date">dia</param>
        /// <param name="userId">Id Usuario</param>
        /// <returns></returns>
        Day? GetDayByDate(DateOnly date, int userId);
    }
}
