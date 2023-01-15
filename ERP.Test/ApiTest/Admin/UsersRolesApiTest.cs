using AutoFixture;

using ERP.Api.Controllers.Admin;
using ERP.Api.Controllers.InOut;
using ERP.Dtos.InOut;
using ERP.Entities.UnitOfWork;
using ERP.Models.InOut;
using ERP.Service.Admin;
using ERP.Service.Crud;
using ERP.Service.InOut;
using Microsoft.EntityFrameworkCore;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Test.ApiTest.Admin
{
    public class UsersRolesApiTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;          
        private readonly UsersRolesController _usersRolesController;
        private readonly IUsersRolesService _usersRolesService;       
        private readonly Fixture _fixture;
        public UsersRolesApiTest()
        {
            
            _unitOfWork = new Mock<IUnitOfWork>();
            _usersRolesService = new UsersRolesService(_unitOfWork.Object);  
            _usersRolesController = new UsersRolesController(_usersRolesService);
            _fixture = new Fixture();

        }

        [Fact]
        public async void Get_Employee_List()
        {
           
            var res = await _usersRolesController.GetAsync(1);

            Xunit.Assert.Equal("Yasin", "");

        }
    }
}
