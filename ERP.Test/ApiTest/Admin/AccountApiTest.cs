using ERP.Api.Controllers.Admin;
using ERP.Entities.Context;
using ERP.Service.Admin;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Test.ApiTest.Admin
{
    //private MyDataBase _ctx;
    //private BaseRepository<Patient> _patientsRepository;
    //private List<Patient> _patients;

    //[TestInitialize]
    //public void Initialize()
    //{
    //    string connStr = ConfigurationManager.ConnectionStrings["MyEntities"].ConnectionString;
    //    DbConnection connection = EntityConnectionFactory.CreateTransient(connStr);
    //    _ctx = new MyEntities(connection);
    //    _patientsRepository = new BaseRepository<Patient>(_ctx);
    //    _patients = GetPatients();
    //}

    [CollectionDefinition("AccountApiCollection")]
    public class CollectionFix: ICollectionFixture<AccountController> {}
    public class AccountApiTestFix : IDisposable
    {
        private AccountController _accountApi;
        private AccountService _accountService;
        public AccountApiTestFix() {

            //_accountService = new AccountService();
            //_accountService = new AccountService();
            //_accountService = new AccountService();
            //_accountApi = new AccountController();
        }  
        public void Dispose()
        {                                         
        }
    }


    [Collection("AccountApiCollection")]
    public class AccountApiTest
    {
        public AccountApiTest(AccountApiTestFix accountApiTest)
        {
        }

        [Fact]
        public void Login_ExeptSucces()
        {          
                         
            //var mytestData = new MyTestData();
            var inputDateTime = new DateTime(2018, 1, 1, 4, 4, 4);
            int result = 25;
            //Assert.Equal(25, result);

        }
    }
}
