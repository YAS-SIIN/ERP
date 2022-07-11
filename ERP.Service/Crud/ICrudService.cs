using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Service.Crud;            

public interface ICrudService<T> where T : class
{
    IQueryable<T> GetAll();
    IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
    T GetById(int id);   
    T Get(Expression<Func<T, bool>> predicate);
    T Insert(T ObjVisit);
    List<T> InsertRange(List<T> ObjVisit);
    T Update(T ObjVisit);
    List<T> UpdateRange(List<T> ObjVisit);
    T Delete(T ObjVisit);
    List<T> DeleteRange(List<T> ObjVisit);
    //------------------- Async
    Task<IQueryable<T>> GetAllAsync();
    Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetByIdAsync(int id);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T> InsertAsync(T ObjVisit);
    Task<List<T>> InsertRangeAsync(List<T> ObjVisit);
    Task<T> UpdateAsync(T ObjVisit);
    Task<List<T>> UpdateRangeAsync(List<T> ObjVisit);
    Task<T> DeleteAsync(T ObjVisit);
    Task<List<T>> DeleteRangeAsync(List<T> ObjVisit);
}
