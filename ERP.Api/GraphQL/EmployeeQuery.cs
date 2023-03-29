using ERP.Entities.Context;
using ERP.Models.Employees;

namespace ERP.Api.GraphQL
{
    public class EmployeeQuery
    {
        //[UserProject]
        public IQueryable<EMPEmployee> GetEMPEmployees([Service] MyDataBase myDataBase) {
          return  myDataBase.EMPEmployees;
        }
    }
}
