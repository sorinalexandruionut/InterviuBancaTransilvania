using MarketingBtrl.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MarketingBtrl.Dal.Repositories;
using MarketingBtrl.Dal.Repositories.Interfaces;

namespace MarketingBtrl.Tests
{
    public class RepositoryBaseFake<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _repositoryContext { get; set; }

        public RepositoryBaseFake(RepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }

        public void Create(T entity)
        {
            this._repositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this._repositoryContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return this._repositoryContext.Set<T>().AsNoTracking();
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._repositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            this._repositoryContext.Set<T>().Update(entity);
        }

        public void Create(T entity, object childEntity)
        {
            this._repositoryContext.Set<T>().Add(entity);
            this._repositoryContext.Entry(childEntity).State = EntityState.Detached;
        }

        public IQueryable<T> ApplyQuery(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }


        public void SetState(T entity, EntityState entityState)
        {
            if (this._repositoryContext.Entry(entity).State != entityState)
            {
                this._repositoryContext.Entry(entity).State = entityState;
            }
        }
    }
}
