using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ERP.Entities.GenericRepository;

public interface IGenericRepository<T> where T : class
{

    bool ExistData();
                                          

    IQueryable<T> GetAll();

    IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
               
    T GetById(object id);

    T Get(Expression<Func<T, bool>> predicate);

    void Add(T entity);

    void AddRange(List<T> entityList);

    void Update(T entity);

    void UpdateRange(List<T> entity);

    void Delete(T entity);

    void DeleteRange(List<T> entity);
    
    //--------

    Task<bool> ExistDataAsync();
    Task<IQueryable<T>> GetAllAsync();

    Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);

    Task<T> GetByIdAsync(object id);

    Task<T> GetAsync(Expression<Func<T, bool>> predicate);

    void AddAsync(T entity);

    void AddRangeAsync(List<T> entityList);
     

}
