using Infraestructure.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DAL.Repositories.Base
{
    public class Repository<T> where T : class
    {
        /// <summary>
        /// Contexto de la base de datos
        /// </summary>
        protected readonly BDContext Context;

        /// <summary>
        /// DbSet de la base de datos
        /// </summary>
        protected readonly DbSet<T> DbSet;

        /// <summary>
        /// Ctor()
        /// </summary>
        /// <param name="dbContext">Contexto de datos de la aplicación</param>
        public Repository(BDContext dbContext)
        {
            Context = dbContext;
            Context.ChangeTracker.LazyLoadingEnabled = false;

            DbSet = dbContext.Set<T>();
        }

        /// <summary>
        /// Guarda en base de datos la información de la entidad
        /// </summary>
        /// <param name="entity">Entidad de tipo T a guardar</param>
        public void Create(T entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        /// <see cref="IRepository{T}.Attach(T)"/>
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            DbSet.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Elimina una entidad de tipo T en base de datos
        /// </summary>
        /// <param name="entity">Entidad de tipo T a borrar</param>
        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        /// <summary>
        /// <see cref="IRepository{T}.Attach(T)"/>
        /// </summary>
        /// <param name="entity"></param>
        public void Attach(T entity)
        {
            DbSet.Attach(entity);
        }

        /// <summary>
        /// <see cref="IRepository{T}.AttachRange(List{T})"/>
        /// </summary>
        /// <param name="entity"></param>
        public void AttachRange(List<T> entities)
        {
            DbSet.AttachRange(entities);
        }

        /// <summary>
        /// <see cref="IRepository.GetAll(string)"/>
        /// </summary>
        /// <param name="master">Nombre de la maestra a obtener los datos</param>
        /// <param name="asNoTracking">Almacenamiento en DbContext. True/False</param>
        /// <returns>Listado de datos</returns>
        public IEnumerable<T> GetAll()
        {
            //No trackeado. Si se modifica un registro no se actualiza en base de datos ni en el contexto
            return DbSet.AsNoTracking();
        }

        /// <summary>
        /// <see cref="IRepository.GetAllIQuerable(bool)"/>
        /// </summary>
        /// <param name="asNotTracking"></param>
        /// <returns></returns>
        public IQueryable<T> GetAllIQuerable(bool asNotTracking = false)
        {
            if (!asNotTracking)
                return DbSet.AsNoTracking();
            else
                return DbSet.AsTracking();
        }

        /// <summary>
        /// <see cref="IRepository.GetElementsByIdIQuerable(bool)"/>
        /// </summary>
        /// <param name="asNotTracking"></param>
        /// <returns></returns>
        public IQueryable<T> GetElementsByIdIQuerable(int id, bool asNotTracking = false)
        {
            var type = typeof(T);
            var param = Expression.Parameter(type, "x");
            var _property = Expression.Property(param, "Id");
            var constant = Expression.Constant(id);
            var body = Expression.Equal(_property, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(body, param);

            var query = DbSet.AsNoTracking().Where(lambda);

            if (asNotTracking)
                query = query.AsTracking();

            return query;
        }

        /// <summary>
        /// <see cref="IRepository.GetElementById(string)"/>
        /// </summary>
        /// <param name="id">Identificador a buscar</param>
        /// <param name="asNoTracking">Almacenamiento en DbContext. True/False</param>
        /// <returns>Elemento</returns>
        public T? GetElementById(int id, bool asNoTracking = false)
        {
            if (!asNoTracking)
            {
                var entity = DbSet.Find(id);

                if (entity != null)
                    DbSet.Entry(entity).State = EntityState.Detached;

                return entity;
            }
            else
            {
                var entity = DbSet.Find(id);

                if (entity != null)
                    DbSet.Entry(entity).State = EntityState.Unchanged;

                return entity;
            }
        }

        /// <summary>
        /// <see cref="IRepository.GetFiltersByField(string, string)"/>
        /// </summary>
        /// <param name="property"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<T> GetFiltersByField(string property, object filter)
        {
            var type = typeof(T);
            var param = Expression.Parameter(type, "x");
            var _property = Expression.Property(param, property);
            var constant = Expression.Constant(filter);
            var body = Expression.Equal(_property, constant);
            var lambda = Expression.Lambda<Func<T, bool>>(body, param);

            return DbSet.AsNoTracking().Where(lambda);
        }

        /// <summary>
        /// <see cref="IRepository{T}.GetListSelectCondition(string, Expression{Func{T, bool}}?, string[]?, Expression{Func{T, object}}[]?)"/>
        /// </summary>
        /// <param name="select"></param>
        /// <param name="where"></param>
        /// <param name="ordersBy"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public dynamic GetListSelectCondition(string select, Expression<Func<T, bool>>? where, string[]? ordersBy, params Expression<Func<T, object>>[]? includes)
        {
            bool orderByFirts = true;
            var query = DbSet.AsQueryable();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            if (where != null)
                query = query.Where(where);

            query = query.Select(BuildSelector(select));

            if (ordersBy != null)
            {
                foreach (var orderBy in ordersBy)
                {
                    if (orderByFirts)
                    {
                        orderByFirts = false;
                        query = query.OrderBy(ToLambda(orderBy));
                    }
                    else
                        query = ((IOrderedQueryable<T>)query).ThenBy(ToLambda(orderBy));
                }
            }

            return query;
        }


        /// <summary>
        /// <see cref="IRepository.GetItemByConditionWithIncludes(Expression{Func{T, bool}}, bool, Expression{Func{T, object}}[])"/>
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="tracking"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public T GetItemByConditionWithIncludes(Expression<Func<T, bool>> condition, bool tracking = false, params Expression<Func<T, object>>[] includes)
        {
            var query = DbSet.AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            query = !tracking ? query.AsNoTracking() : query.AsTracking();

            return query.FirstOrDefault(condition);
        }


        #region Private

        /// <summary>
        /// Método que genera una expresión de un string con los campos a seleccionar separados por coma
        /// En caso de propiedad compleja debe de ir separada por un punto
        /// </summary>
        /// <typeparam name="T">Clase de dominio en la que buscar</typeparam>
        /// <param name="members">Cadena con los campos a seleccionar separados por coma</param>
        /// <returns>Expresión lambda</returns>
        private Expression<Func<T, T>> BuildSelector(string members)
        {
            var lMembers = members.Split(',').Select(m => m.Trim());

            var parameter = Expression.Parameter(typeof(T), "x");
            var body = NewObject(typeof(T), parameter, lMembers.Select(m => m.Split('.')));
            return Expression.Lambda<Func<T, T>>(body, parameter);
        }

        /// <summary>
        /// Método que crea una nueva expresión
        /// </summary>
        /// <param name="targetType">Tipo de la entidad resultado</param>
        /// <param name="source">Expresion a completar</param>
        /// <param name="memberPaths">Listado con los campos a seleccionar</param>
        /// <param name="depth">Flag</param>
        /// <returns>Expresión lambda</returns>
        private Expression NewObject(Type targetType, Expression source, IEnumerable<string[]> memberPaths, int depth = 0)
        {
            var bindings = new List<MemberBinding>();
            var target = Expression.Constant(null, targetType);
            foreach (var memberGroup in memberPaths.GroupBy(path => path[depth]))
            {
                var memberName = memberGroup.Key;
                var targetMember = Expression.PropertyOrField(target, memberName);
                var sourceMember = Expression.PropertyOrField(source, memberName);
                var childMembers = memberGroup.Where(path => depth + 1 < path.Length).ToList();

                Expression? targetValue = null;
                if (!childMembers.Any())
                    targetValue = sourceMember;
                else
                {
                    if (IsEnumerableType(targetMember.Type, out var sourceElementType) &&
                        IsEnumerableType(targetMember.Type, out var targetElementType))
                    {
                        var sourceElementParam = Expression.Parameter(sourceElementType, "e");
                        targetValue = NewObject(targetElementType, sourceElementParam, childMembers, depth + 1);
                        targetValue = Expression.Call(typeof(Enumerable), nameof(Enumerable.Select),
                            new[] { sourceElementType, targetElementType }, sourceMember,
                            Expression.Lambda(targetValue, sourceElementParam));

                        targetValue = CorrectEnumerableResult(targetValue, targetElementType, targetMember.Type);
                    }
                    else
                        targetValue = NewObject(targetMember.Type, sourceMember, childMembers, depth + 1);
                }

                bindings.Add(Expression.Bind(targetMember.Member, targetValue));
            }
            return Expression.MemberInit(Expression.New(targetType), bindings);
        }

        /// <summary>
        /// Método que indica si se trata de un tipo Enumerable
        /// </summary>
        /// <param name="type">Tipo del elemento</param>
        /// <param name="elementType">Tipo de salida</param>
        /// <returns>Boolean True/False</returns>
        private bool IsEnumerableType(Type type, out Type elementType)
        {
            foreach (var intf in type.GetInterfaces())
            {
                if (intf.IsGenericType && intf.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    elementType = intf.GetGenericArguments()[0];
                    return true;
                }
            }

            elementType = type;
            return false;
        }

        /// <summary>
        /// Método que comprueba si se trata de una misma colección
        /// </summary>
        /// <param name="type">Tipo de elemento</param>
        /// <param name="genericType">Tipo de elemento</param>
        /// <param name="elementType">Tipo de elemento</param>
        /// <returns>Boolean que indica True/False</returns>
        private bool IsSameCollectionType(Type type, Type genericType, Type elementType)
        {
            var result = genericType.MakeGenericType(elementType).IsAssignableFrom(type);
            return result;
        }

        /// <summary>
        /// Método que genera un resultado enumerable
        /// </summary>
        /// <param name="enumerable">Expresión</param>
        /// <param name="elementType">Type del elemento </param>
        /// <param name="memberType">Type del elemento membertype</param>
        /// <returns>Expresion</returns>
        /// <exception cref="NotImplementedException"></exception>
        private Expression CorrectEnumerableResult(Expression enumerable, Type elementType, Type memberType)
        {
            if (memberType == enumerable.Type)
                return enumerable;

            if (memberType.IsArray)
                return Expression.Call(typeof(Enumerable), nameof(Enumerable.ToArray), new[] { elementType }, enumerable);

            if (IsSameCollectionType(memberType, typeof(List<>), elementType)
                || IsSameCollectionType(memberType, typeof(ICollection<>), elementType)
                || IsSameCollectionType(memberType, typeof(IReadOnlyList<>), elementType)
                || IsSameCollectionType(memberType, typeof(IReadOnlyCollection<>), elementType))
                return Expression.Call(typeof(Enumerable), nameof(Enumerable.ToList), new[] { elementType }, enumerable);

            throw new NotImplementedException($"Not implemented transformation for type '{memberType.Name}'");
        }

        /// <summary>
        /// Método que convierte el nombre de una propiedad (string) en una expresión Lambda
        /// </summary>
        /// <typeparam name="T">Tipo de entidad</typeparam>
        /// <param name="propertyName">Nombre de la propiedad</param>
        /// <returns>Expresión Lambda</returns>
        private Expression<Func<T, object>> ToLambda(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }

        #endregion

        #region Protected

        /// <summary>
        /// Método que retorna una query en formato string para realizar un borrado lógico de una tabla estandar en base a un Id o una condicion where especifica.
        /// </summary>
        /// <param name="nombreTabla"></param>
        /// <param name="id"></param>
        /// <param name="usuarioModificacion"></param>
        /// <param name="fechaModificacion"></param>
        /// <param name="condicionWhere"></param>
        /// <returns></returns>
        protected string GetDeleteQuery(string nombreTabla, int id, string usuarioModificacion, DateTime fechaModificacion, string condicionWhere = null)
        {
            var query = $@"Update [dbo].[{nombreTabla}]
                          SET Borrado=true,
                            UsuarioModificacion='{usuarioModificacion}',
                            FechaModificacion='{fechaModificacion}' ";

            if (string.IsNullOrEmpty(condicionWhere))
            {
                query += $"WHERE Id = {id};";
            }
            else
            {
                query += $"WHERE {condicionWhere};";
            }

            return query;
        }

        #endregion
    }
}
