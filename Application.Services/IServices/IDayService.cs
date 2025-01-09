using Domain.Dtos;
using Domain.Dtos.ListDto;
using Domain.Searchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IServices
{
    /// <summary>
    /// Servicio Day
    /// </summary>
    public interface IDayService
    {
        /// <summary>
        /// Metodo que obtiene todos los dias
        /// </summary>
        /// <returns></returns>
        List<ListDayDto> GetAllDays();

        /// <summary>
        /// Metodo que obtiene todos los dias con sus menus de un periodo
        /// </summary>
        /// <param name="search">Search</param>
        /// <returns></returns>
        List<ListDayDto> GetDaysByPeriod(DaysByPeriodSerach search);

        /// <summary>
        /// Metodo que edita o agrega un dia
        /// </summary>
        /// <param name="dto">Dto</param>
        void AddEditMealDay(DayDto dto);

        /// <summary>
        /// Metodo que edita o agrega un dia
        /// </summary>
        /// <param name="dto">Dto</param>
        void AddEditDinnerDay(DayDto dto);
    }
}
