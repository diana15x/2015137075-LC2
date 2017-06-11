using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2015137075.ENT.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //Metodos estándar que toda tabla debe tener

        //CREATES
        // se agrega registro al repositorio sql server a la tabla TEntity
        void Add(TEntity entity);
        // se agrega grupo de registros al repositorio sql server a la tabla TEntity
        void AddRange(IEnumerable<TEntity> entities);

        //READS
        //Obtiene el registro con primary key = Id de la tabla TEntity

        TEntity Get(int Id);
        // obtiene todos los reistros de la tabla TEntity
        IEnumerable<TEntity> GetAll();
        // obtiene todos los registros de la tabla Tentity que cumplan con la condicion predicate
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //UPDATE
        // actualiza un registro al repositorio sql server a la tabla TEntity
        //void Update(TEntity entity);
        // actualiza un grupo de registros al repositorio sql server a la tabla TEntity
        //void UpdateRange(IEnumerable<TEntity> entities);

        //DELETE
        // elimina un registro al repositorio sql server a la tabla TEntity
        void Delete(TEntity entity);
        // elimina un  grupo de registros al repositorio sql server a la tabla TEntity
        void DeleteRange(IEnumerable<TEntity> entities);

    }
}
