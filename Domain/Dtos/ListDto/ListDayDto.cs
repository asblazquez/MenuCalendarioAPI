using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.ListDto
{
    /// <summary>
    /// ListDayDto
    /// </summary>
    public class ListDayDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Meal
        /// </summary>
        public SelectListItemDto? Meal { get; set; }

        /// <summary>
        /// Dinner
        /// </summary>
        public SelectListItemDto? Dinner { get; set; }
    }
}
