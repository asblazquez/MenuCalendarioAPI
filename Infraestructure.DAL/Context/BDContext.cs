using Microsoft.EntityFrameworkCore;

namespace Infraestructure.DAL.Context
{
    public partial class BDContext : DbContext
    {
        public BDContext(DbContextOptions<BDContext> options) : base(options)
        {
        }
    }
}
