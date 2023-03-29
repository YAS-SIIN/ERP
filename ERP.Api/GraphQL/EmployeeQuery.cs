using ERP.Entities.Context;
using ERP.Models.Employees;

using HotChocolate.Execution;

namespace ERP.Api.GraphQL
{
    public class EmployeeQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<EMPEmployee> GetEMPEmployees([Service] MyDataBase myDataBase) {
          return  myDataBase.EMPEmployees;
        }
    }
}
