using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MarketingBtrl.Dal.Repositories.Interfaces;

namespace MarketingBtrl.DAL.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void CreateRange(List<T> entities)
        {
            this.RepositoryContext.Set<T>().AddRange(entities);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Create(T entity, object childEntity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
            this.RepositoryContext.Entry(childEntity).State = EntityState.Detached;
        }


        public IQueryable<T> ApplyQuery(string query, params object[] parameters)
        {
            if (parameters == null)
            {
                return this.RepositoryContext.Set<T>().FromSqlRaw(query).AsNoTracking();
            }
            return this.RepositoryContext.Set<T>().FromSqlRaw(query, parameters).AsNoTracking();
        }

        public void SetState(T entity, EntityState entityState)
        {
            if (entity != null)
            {
                this.RepositoryContext.Entry(entity).State = entityState;
            }
        }
    }
}
