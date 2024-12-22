using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DAL.IRepositories.Base
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Guarda en base de datos la información de la entidad
        /// </summary>
        /// <param name="entity">Entidad de tipo T a guardar</param>
        void Create(T entity);

        /// <summary>
        /// Cambia el estado de una entidad para ser modificada
        /// </summary>
        /// <param name="entity">Entidad de tipo T a la que se modifica el estado</param>
        void Update(T entity);

        /// <summary>
        /// Elimina una entidad de tipo T en base de datos
        /// </summary>
        /// <param name="entity">Entidad de tipo T a borrar</param>
        void Delete(T entity);

        /// <summary>
        /// Realiza un attach de la entidad proporcionada
        /// </summary>
        /// <param name="entity">Entidad</param>
        void Attach(T entity);

        /// <summary>
        /// Realiza un attach del listado de la entidad proporcionada
        /// </summary>
        /// <param name="entities">Listado de las entidades</param>
        void AttachRange(List<T> entities);

        /// <summary>
        /// Método obtiene de base de datos todos los datos de una tabla
        /// </summary>
        /// <returns>Listado de datos</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Método que obtiene de base de datos un dato de una tabla, dado el Id del registro a buscar
        /// </summary>
        /// <param name="id">Identificador a buscar</param>
        /// <param name="asNoTracking">Almacenamiento en DbContext. Por defecto false, no se trackea en el contexto</param>
        /// <returns>Elemento concreto</returns>
        T? GetElementById(int id, bool asNoTracking = false);

        /// <summary>
        /// Método que obtiene de base de datos todos los datos de una tabla
        /// </summary>
        /// <param name="asNotTracking">Por defecto false, no se trackea en el contexto</param>
        /// <returns>Consulta de datos</returns>
        IQueryable<T> GetAllIQuerable(bool asNotTracking = false);

        /// <summary>
        /// Método que obtiene de base de datos los datos de un elemento concreto
        /// </summary>
        /// <param name="id">Identificador a buscar</param>
        /// <param name="asNotTracking">Por defecto false, no se trackea en el contexto</param>
        /// <returns>Consulta de datos</returns>
        IQueryable<T> GetElementsByIdIQuerable(int id, bool asNotTracking = false);

        /// <summary>
        /// Método obtiene de base de datos todos los datos de una tabla filtrados por un campo
        /// </summary>
        /// <param name="property">Campo por el que filtrar</param>
        /// <param name="filter">Valor por le que filtrar el campo</param>
        /// <returns>Listado de datos filtrados por la propiedad y el valor indicado en los parámetros</returns>
        IEnumerable<T> GetFiltersByField(string property, object filter);

        /// <summary>
        /// Método dínamico que devuelve un listado de resultados agrupados o sin agrupar
        /// </summary>
        /// <param name="properties">Listado de propiedades a seleccionar en la consulta separadas por comas</param>
        /// <param name="where">Expressión lambda con las condiciones</param>
        /// <param name="ordersBy">Listado de columnas por la que ordenar la búsqueda</param>
        /// <param name="includes">Expressión lambda con los includes</param>
        /// <returns>Listado de resultados del tipo de la clase del repositorio</returns>
        dynamic GetListSelectCondition(string properties, Expression<Func<T, bool>>? where, string[]? ordersBy, params Expression<Func<T, object>>[]? includes);

        /// <summary>
        /// Obtiene un elemento de tipo T en función de la condición proporcionada permitiendo añadir includes de entidades
        /// relacionadas
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="tracking"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        T GetItemByConditionWithIncludes(Expression<Func<T, bool>> condition, bool tracking = false, params Expression<Func<T, object>>[] includes);
    }
}
