using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Service.Crud;            

internal interface ICrudService<T> where T : class
{
    IQueryable<T> GetAll();
    IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
    T GetById(int id);
    T Insert(T ObjVisit);
    T Update(T ObjVisit);
    T Delete(T ObjVisit);
}
