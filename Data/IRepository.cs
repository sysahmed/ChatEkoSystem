using ChatEkoSystem.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ChatEkoSystem.Data
{
    public interface IRepository<T> where T : class
    {
        IDataResult<List<T>> GetAll();
        IDataResult<List<T>> GetAll(Expression<Func<T, bool>> predicate);
        IDataResult<T> GetById(int id);
        IDataResult<T> Get(Expression<Func<T, bool>> predicate);
        IDataResult<T> Add(T entity);
        IDataResult<T> Update(T entity);
        IResult Delete(T entity);
        IResult Delete(int id);
    }  
}
