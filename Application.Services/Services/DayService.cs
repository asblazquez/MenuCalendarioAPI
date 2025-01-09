using Application.Services.IServices;
using Application.Services.Services.Base;
using Domain.Dtos;
using Domain.Dtos.ListDto;
using Domain.Entities;
using Domain.Searchs;
using Infraestructure.DAL.UnitOfWork;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Services
{
    public class DayService : BaseService, IDayService
    {
        public DayService(IUnitOfWork uow) : base(uow)
        {
        }

        /// <summary>
        /// <see cref="IDayService.GetAllDays"/>
        /// </summary>
        /// <returns></returns>
        public List<ListDayDto> GetAllDays()
        {
            return _uow.Day.GetAllDays();
        }

        /// <summary>
        /// <see cref="IDayService.GetDaysByPeriod"/>
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<ListDayDto> GetDaysByPeriod(DaysByPeriodSerach search)
        {
            return _uow.Day.GetDaysByPeriod(search.StartDate, search.EndDate, LoggedUserService.Instance.UserId);
        }

        /// <summary>
        /// <see cref="IDayService.AddEditMealDay(DayDto)"/>
        /// </summary>
        /// <param name="dto"></param>
        public void AddEditMealDay(DayDto dto)
        {
            Day? day = _uow.Day.GetDayByDate(dto.Date, LoggedUserService.Instance.UserId);

            if(day != null)
            {
                day.IdMeal = dto.IdMenu;
                _uow.Commit();
            } else
            {
                Day newDay = new()
                {
                    Date = dto.Date,
                    IdMeal = dto.IdMenu,
                    IdUsuario = LoggedUserService.Instance.UserId,
                };

                _uow.Day.Create(newDay);
                _uow.Commit();
            }
        }

        /// <summary>
        /// <see cref="IDayService.AddEditDinnerDay(DayDto)"/>
        /// </summary>
        /// <param name="dto"></param>
        public void AddEditDinnerDay(DayDto dto)
        {
            Day? day = _uow.Day.GetDayByDate(dto.Date, LoggedUserService.Instance.UserId);

            if (day != null)
            {
                day.IdDinner = dto.IdMenu;
                _uow.Commit();
            }
            else
            {
                Day newDay = new()
                {
                    Date = dto.Date,
                    IdDinner = dto.IdMenu,
                    IdUsuario = LoggedUserService.Instance.UserId,
                };

                _uow.Day.Create(newDay);
                _uow.Commit();
            }
        }
    }
}
