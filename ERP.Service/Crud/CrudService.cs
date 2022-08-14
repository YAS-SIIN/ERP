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

    public T Get(Expression<Func<T, bool>> predicate)
    {
        return _uw.GetRepository<T>().Get(predicate);
    }

    public T Insert(T ObjVisit)
    {        
        _uw.GetRepository<T>().Add(ObjVisit);
        _uw.SaveChanges();
        return ObjVisit;
    }

    public List<T> InsertRange(List<T> ObjVisit)
    {
        _uw.GetRepository<T>().AddRange(ObjVisit);
        _uw.SaveChanges();
        return ObjVisit;
    }

    public T Update(T ObjVisit)
    {

        _uw.GetRepository<T>().Update(ObjVisit);
        _uw.SaveChanges();
        return ObjVisit;
    }

    public List<T> UpdateRange(List<T> ObjVisit)
    {

        _uw.GetRepository<T>().UpdateRange(ObjVisit);
        _uw.SaveChanges();
        return ObjVisit;
    }
                
    public T Delete(T ObjVisit)
    {

        _uw.GetRepository<T>().Delete(ObjVisit);
        _uw.SaveChanges();
        return ObjVisit;
    }
            
    public List<T> DeleteRange(List<T> ObjVisit)
    {

        _uw.GetRepository<T>().DeleteRange(ObjVisit);
        _uw.SaveChanges();
        return ObjVisit;
    }

    //----------------- Async

    public async Task<IQueryable<T>> GetAllAsync()
    {
        return await _uw.GetRepository<T>().GetAllAsync();
    }

    public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
    {
        return await _uw.GetRepository<T>().GetAllAsync(predicate);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _uw.GetRepository<T>().GetByIdAsync(id);
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _uw.GetRepository<T>().GetAsync(predicate);
    }

    public Task<T> InsertAsync(T ObjVisit)
    {
        _uw.GetRepository<T>().AddAsync(ObjVisit);
        _uw.SaveChanges();
        return Task.FromResult(ObjVisit);
    }

    public Task<List<T>> InsertRangeAsync(List<T> ObjVisit)
    {
        _uw.GetRepository<T>().AddRangeAsync(ObjVisit);
        _uw.SaveChanges();
        return Task.FromResult(ObjVisit);
    }

    public Task<T> UpdateAsync(T ObjVisit)
    {
        _uw.GetRepository<T>().Update(ObjVisit);
        _uw.SaveChanges();
        return Task.FromResult(ObjVisit);
    }

    public Task<List<T>> UpdateRangeAsync(List<T> ObjVisit)
    {
        _uw.GetRepository<T>().UpdateRange(ObjVisit);
        _uw.SaveChanges();
        return Task.FromResult(ObjVisit);
    }

    public Task<T> DeleteAsync(T ObjVisit)
    {
        _uw.GetRepository<T>().Delete(ObjVisit);
        _uw.SaveChanges();
        return Task.FromResult(ObjVisit);
    }

    public Task<List<T>> DeleteRangeAsync(List<T> ObjVisit)
    {
        _uw.GetRepository<T>().DeleteRange(ObjVisit);
        _uw.SaveChanges();
        return Task.FromResult(ObjVisit);
    }

}
