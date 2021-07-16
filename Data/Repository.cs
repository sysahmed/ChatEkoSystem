using ChatEkoSystem.Core;
using ChatEkoSystem.Core.Utility;
using ChatEkoSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ChatEkoSystem.Data
{
    public class Repository<T>: IRepository<T> where T : class
    {
        protected readonly Context _context;
        private readonly DbSet<T> _dbSet;


        public Repository(Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        IDataResult<List<T>> IRepository<T>.GetAll()
        {
            return new DataResult<List<T>>(_dbSet.ToList(), true, Messages.DataGetAll);
        }

        IResult IRepository<T>.Delete(T entity)
        {
            _dbSet.Remove(entity);
            return new Results(true, Messages.DataDeleted);
        }

        IDataResult<List<T>> IRepository<T>.GetAll(Expression<Func<T, bool>> predicate)
        {
            return new DataResult<List<T>>(_dbSet.Where(predicate).ToList(), true, Messages.DataGetAll);
        }

        IDataResult<T> IRepository<T>.GetById(int id)
        {
            return new DataResult<T>(_dbSet.Find(id), true, Messages.DataGetAll);
        }

        IDataResult<T> IRepository<T>.Get(Expression<Func<T, bool>> predicate)
        {
            return new DataResult<T>(_dbSet.Where(predicate).SingleOrDefault(), true, Messages.DataGetAll);
        }

        IDataResult<T> IRepository<T>.Add(T entity)
        {
            return new DataResult<T>(_dbSet.Add(entity).Entity, true, Messages.DataAdded);
        }

        IDataResult<T> IRepository<T>.Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return new DataResult<T>(entity, true, Messages.DataUpdated);
        }

        IResult IRepository<T>.Delete(int id)
        {
            _dbSet.Find(id);
            return new Results(true, Messages.DataDeleted);
        }
    }
}
