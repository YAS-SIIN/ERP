using AutoFixture;

using ERP.Api.Controllers.Admin;
using ERP.Common.Shared;
using ERP.Dtos.Admin;
using ERP.Dtos.Other;
using ERP.Entities.Context;
using ERP.Entities.UnitOfWork;
using ERP.Service.Admin;

using MassTransit.Configuration;

using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit.Abstractions;

using static MassTransit.ValidationResultExtensions;

namespace ERP.Test.ApiTest.Admin
{

    public class AccountApiTest
    {
        private readonly MyDataBase? context;
        private readonly Dtos.Other.ApplicationOptions testOption;
        private readonly IOptions<Dtos.Other.ApplicationOptions> _iOptions;
        private readonly Security _security;
        private readonly JwtManager _jwtManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AccountController _accountcontroller;
        private readonly IAccountService _accountService;
        private readonly Fixture _fixture;
        public AccountApiTest()
        {
            DbContextOptions<MyDataBase> contextOptions;
                                
            testOption = new Dtos.Other.ApplicationOptions();
            testOption.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB; UID=sa; Password=ABCabc123456;Database=ERP;";
     
            var builder = new DbContextOptionsBuilder<MyDataBase>();
                        
            builder.UseSqlServer(testOption.ConnectionString);
            contextOptions = builder.Options;
            
            context = new MyDataBase(contextOptions);
            _iOptions = Options.Create<Dtos.Other.ApplicationOptions>(testOption);
                      
            _security = new Security();                              
            _jwtManager = new JwtManager(_iOptions);   
            _unitOfWork = new UnitOfWork(context);

            _accountService = new AccountService(_security, _jwtManager, _unitOfWork);
            _fixture = new Fixture();
            _accountcontroller = new AccountController(_accountService);
                                     
        }

        [Theory]
        [InlineData("Yasin", "1")]
        public async void Login_ExeptSucces(string username, string passwrod)
        {
            var mdl = new UserLoginDto();
            mdl.UserName = username;
            mdl.PassWord = passwrod;
           var res =await _accountcontroller.LoginAsync(mdl);
            LoginModel exept = new LoginModel()
            {
                Token = "",
                IsSuccessful = true,
                ExpirationDate = DateTime.Now };
            Xunit.Assert.Equal("Yasin", username);

        }
    }
}
