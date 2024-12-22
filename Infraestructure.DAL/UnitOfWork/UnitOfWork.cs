using Infraestructure.DAL.Context;
using Infraestructure.DAL.IRepositories;
using Infraestructure.DAL.Repositories;

namespace Infraestructure.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BDContext _context = null!;

        private IDayRepository _day = null!;

        public UnitOfWork(BDContext context)
        {
            _context = context;
        }

        public IDayRepository Day => _day ??= new DayRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
