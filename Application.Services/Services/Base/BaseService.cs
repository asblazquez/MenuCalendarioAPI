using Infraestructure.DAL.UnitOfWork;

namespace Application.Services.Services.Base
{
    public class BaseService
    {
        protected readonly IUnitOfWork _uow;

        public BaseService(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
