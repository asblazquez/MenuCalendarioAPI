using Domain.Dtos.ListDto;
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
    }
}
