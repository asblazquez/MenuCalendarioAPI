using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Searchs
{
    /// <summary>
    /// Clase que representa el modelo de busqueda de dias por periodo
    /// </summary>
    public class DaysByPeriodSerach
    {
        /// <summary>
        /// Fecha de inicio
        /// </summary>
        public DateOnly StartDate { get; set; }

        /// <summary>
        /// Fecha de fin
        /// </summary>
        public DateOnly EndDate { get; set; }

    }
}
