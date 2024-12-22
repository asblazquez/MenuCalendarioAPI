using Infraestructure.DAL.Context;

namespace Infraestructure.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BDContext _context = null!;

        public UnitOfWork(BDContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
