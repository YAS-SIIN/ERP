using ERP.Entities.Context;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ERP.Entities.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{

    private readonly MyDataBase _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(MyDataBase context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public bool ExistData()
    {
        return _dbSet.Any();
    }

    public bool ExistData(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate).Any();
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet;
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public T GetById(object id)
    {
        return _dbSet.Find(id);
    }

    public T Get(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate).SingleOrDefault();
    }

    public virtual void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void AddRange(List<T> entityList)
    {
        _dbSet.AddRange(entityList);
    }

    public virtual void Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public virtual void UpdateRange(List<T> entity)
    {
        _dbSet.AttachRange(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }


    public virtual void Delete(T entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
            _dbSet.Attach(entity);
        _dbSet.Remove(entity);
    }

    public virtual void DeleteRange(List<T> entity)
    {
        _dbSet.RemoveRange(entity);
    }
    //--------------
       
    public async Task<bool> ExistDataAsync()
    {
        return await _dbSet.AnyAsync();
    }
    public async Task<bool> ExistDataAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).AnyAsync();
    }


    public async Task<IQueryable<T>> GetAllAsync()
    {
        var data = await _dbSet.ToListAsync();
        return data.AsQueryable();
    }
    public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
    {
          var data = await _dbSet.Where(predicate).ToListAsync();
        return data.AsQueryable();
    }

    public async Task<T> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).SingleOrDefaultAsync();
    }

    public async virtual Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async virtual Task AddRangeAsync(List<T> entityList)
    {
        await _dbSet.AddRangeAsync(entityList);
    }
 
    
}
