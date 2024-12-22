using Application.Services.IServices;
using Application.Services.Services.Base;
using Domain.Dtos.ListDto;
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
    }
}
