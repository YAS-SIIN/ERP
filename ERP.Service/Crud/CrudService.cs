using ERP.Entities.UnitOfWork;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Service.Crud;

public class CrudService <T> : ICrudService<T> where T : class
{
    private readonly IUnitOfWork _uw;
    public CrudService(IUnitOfWork uw)
    {
        _uw = uw;
    }
    public IQueryable<T> GetAll()
    {
        return _uw.GetRepository<T>().GetAll();
    }
    public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        return _uw.GetRepository<T>().GetAll(predicate);
    }
    public T GetById(int id)
    {
        return _uw.GetRepository<T>().GetById(id);
    }

    public T Insert(T ObjVisit)
    {        
        _uw.GetRepository<T>().Add(ObjVisit);
        _uw.SaveChanges();
        return ObjVisit;
    }

    public T Update(T ObjVisit)
    {

        _uw.GetRepository<T>().Update(ObjVisit);
        _uw.SaveChanges();
        return ObjVisit;
    }

    public T Delete(T ObjVisit)
    {

        _uw.GetRepository<T>().Delete(ObjVisit);
        _uw.SaveChanges();
        return ObjVisit;
    }

}
