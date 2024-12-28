using Domain.Dtos.ListDto;
using Domain.Entities;
using Infraestructure.DAL.Context;
using Infraestructure.DAL.IRepositories;
using Infraestructure.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.DAL.Repositories
{
    public class DayRepository : Repository<Day>, IDayRepository
    {
        public DayRepository(BDContext context) : base(context)
        {
        }

        /// <summary>
        /// <see cref="IDayRepository.GetAllDays"/>
        /// </summary>
        /// <returns></returns>
        public List<ListDayDto> GetAllDays()
        {
            return Context.Days
                .Include(x => x.Meal)
                .Include(x => x.Dinner)
                .Select(x => new ListDayDto
                {
                    Id = x.Id,
                    Date = x.Date,
                    TitleMeal = x.Meal.Title,
                    TitleDinner = x.Dinner.Title
                }).ToList();
        }

        /// <summary>
        /// <see cref="IDayRepository.GetDaysByPeriod(DateOnly, DateOnly)"/>
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<ListDayDto> GetDaysByPeriod(DateOnly startDate, DateOnly endDate)
        {
            return Context.Days
                .Where(x => x.Date >= startDate && x.Date <= endDate && x.IdUsuario == 1)
                .Select(x => new ListDayDto()
                {
                    Id = x.Id,
                    Date = x.Date,
                    TitleMeal = x.Meal.Title,
                    TitleDinner = x.Dinner.Title
                }).ToList();
        }
    }
}
