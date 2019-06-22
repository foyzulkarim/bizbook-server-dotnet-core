using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.Model;

namespace Model
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> Filter(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        IQueryable<TEntity> Get();
        TEntity GetById(string id);
        bool Exists(string id);
        EntityEntry<TEntity> Add(TEntity entity);
        IEnumerable<TEntity> Add(IEnumerable<TEntity> entities);
        bool Delete(TEntity entity);
        bool Delete(string id);
        bool Edit(TEntity entity);
        bool Save();

        BizBookInventoryContext Db { get; set; }
    }
}