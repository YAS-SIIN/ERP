using AutoFixture;
using ERP.Api.Controllers.Admin;
using ERP.Api.Controllers.Employees;
using ERP.Common.Shared;
using ERP.Dtos.Admin;
using ERP.Entities.UnitOfWork;
using ERP.Models.Employees;
using ERP.Service.Admin;
using ERP.Service.Crud;
using ERP.Service.Employees;

using Microsoft.Extensions.Options;
using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Test.ApiTest.Employees
{
    public class EmployeeApiTest
    {
        private readonly ISecurity _security;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly EmployeeController _employeecontroller;
        private readonly IEmployeesService _accountService;
        private readonly ICrudService<EMPEmployee> _crudService;
        private readonly Fixture _fixture;
        public EmployeeApiTest()
        {
            _security = new ERP.Common.Shared.Security();    
            _unitOfWork = new Mock<IUnitOfWork>();
            _accountService = new EmployeesService(_unitOfWork.Object, _security);
            _crudService = new CrudService<EMPEmployee>(_unitOfWork.Object);
            _fixture = new Fixture();
            _employeecontroller = new EmployeeController(_crudService, _accountService);

        }

        [Fact]                    
        public async void Get_Employee_List()
        {
            string test = "";
            var res = await _employeecontroller.GetAsync();
        
            Xunit.Assert.Equal("Yasin", test);

        }
    }
}
