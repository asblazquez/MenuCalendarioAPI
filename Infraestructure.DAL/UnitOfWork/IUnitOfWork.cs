using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Guarda los cambios de todos los repositorios en BBDD
        /// </summary>
        void Commit();
    }
}
