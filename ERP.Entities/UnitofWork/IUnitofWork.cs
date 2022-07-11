using ERP.Entities.GenericRepository;
using System;

namespace ERP.Entities.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> GetRepository<T>() where T : class;

    void SaveChanges();

}
