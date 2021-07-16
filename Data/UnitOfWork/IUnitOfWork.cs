using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatEkoSystem.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}
