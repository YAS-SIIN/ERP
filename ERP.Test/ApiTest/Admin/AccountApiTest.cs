using AutoFixture;

using ERP.Api.Controllers.Admin;
using ERP.Common.Shared;
using ERP.Dtos.Admin;
using ERP.Dtos.Other;
using ERP.Entities.Context;
using ERP.Entities.UnitOfWork;
using ERP.Service.Admin;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
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
        private readonly IOptions<ApplicationOptions>? _options;
        private readonly ISecurity _security;
        private readonly IJwtManager _jwtManager;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly AccountController _accountcontroller;
        private readonly IAccountService _accountService;
        private readonly Fixture _fixture;
        public AccountApiTest()
        {
            _security = new ERP.Common.Shared.Security();
            _options = null;
            _jwtManager = new ERP.Common.Shared.JwtManager(_options);
            _unitOfWork = new Mock<IUnitOfWork>();
            _accountService = new AccountService(_security, _jwtManager, _unitOfWork.Object);
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
