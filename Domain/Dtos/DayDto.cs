using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class DayDto
    {
        /// <summary>
        /// Dia
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Menu
        /// </summary>
        public int IdMenu { get; set; }
    }
}
