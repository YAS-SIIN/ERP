using ERP.Entities.GenericRepository;
using System;

namespace ERP.Entities.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> GetRepository<T>() where T : class;

    object ExecuteSqlRaw(string strQuery, object[] parametrs);
    Task<object> ExecuteSqlRawAsync(string strQuery, object[] parametrs);
    void SaveChanges();  
    void SaveChangesAsync();

}
