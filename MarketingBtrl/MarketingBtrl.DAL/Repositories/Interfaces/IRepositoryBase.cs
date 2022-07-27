using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MarketingBtrl.Dal.Repositories.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        void Create(T entity);
        void Create(T entity, object childEntity);
        void Update(T entity);
        void Delete(T entity);
        void SetState(T entity, EntityState entityState);

        IQueryable<T> ApplyQuery(string query, params object[] parameters);
    }
}
