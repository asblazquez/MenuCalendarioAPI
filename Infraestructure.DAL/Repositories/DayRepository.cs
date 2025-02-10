using Domain.Dtos.ListDto;
using Domain.Entities;
using Infraestructure.DAL.Context;
using Infraestructure.DAL.IRepositories;
using Infraestructure.DAL.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Utils;

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
                    Meal =  new() { Value = x.Meal.Id, Text = x.Meal.Title },
                    Dinner = new() { Value = x.Dinner.Id, Text = x.Dinner.Title }
                }).ToList();
        }

        /// <summary>
        /// <see cref="IDayRepository.GetDaysByPeriod(DateOnly, DateOnly)"/>
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<ListDayDto> GetDaysByPeriod(DateOnly startDate, DateOnly endDate, int userId)
        {
            return Context.Days
                .Where(x => x.Date >= startDate && x.Date <= endDate && x.IdUsuario == userId)
                .Select(x => new ListDayDto()
                {
                    Id = x.Id,
                    Date = x.Date,
                    Meal = x.Meal.Id != null ? new () { Value = x.Meal.Id, Text = x.Meal.Title } : null,
                    Dinner = x.Dinner.Id != null ? new () { Value = x.Dinner.Id, Text = x.Dinner.Title } : null
                }).ToList();
        }

        /// <summary>
        /// <see cref="IDayRepository.GetDayByDate(DateOnly, int)"/>
        /// </summary>
        /// <param name="date"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Day? GetDayByDate(DateOnly date, int userId)
        {
            return Context.Days
                .Include(x => x.Meal)
                .Include(x => x.Dinner)
                .FirstOrDefault(x => x.Date == date && x.IdUsuario == userId);
        }
    }
}
