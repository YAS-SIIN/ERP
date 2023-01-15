using ERP.Common.Shared;
using ERP.Entities.Context;
using ERP.Entities.UnitOfWork;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Test
{
    public class TestTool
    {
        private MyDataBase? context;
        private DbContextOptions<MyDataBase> contextOptions;
        private Dtos.Other.ApplicationOptions testOption;
        private IOptions<Dtos.Other.ApplicationOptions> _iOptions;
        public Security _security;
        public JwtManager _jwtManager;
        public IUnitOfWork _unitOfWork;

        public TestTool()
        {
            testOption = new Dtos.Other.ApplicationOptions();
            testOption.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB; UID=sa; Password=ABCabc123456;Database=ERP;";
            testOption.JwtSecret = "A_STRONG_KEY";
            testOption.JwtKey = "Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx";
            testOption.JwtIssuer = "JWTAuthenticationServer";
            testOption.JwtAudience = "JWTServicePostmanClient";
            testOption.JwtSubject = "JWTServiceAccessToken";

            _iOptions = Options.Create<Dtos.Other.ApplicationOptions>(testOption);

            _security = new Security();
            _jwtManager = new JwtManager(_iOptions);
        }
        public void ConectToDatabase()
        {
            var builder = new DbContextOptionsBuilder<MyDataBase>();

            builder.UseSqlServer(testOption.ConnectionString);
            contextOptions = builder.Options;
            context = new MyDataBase(contextOptions);
            _unitOfWork = new UnitOfWork(context);
        }
              
        public void Dispose() { }
    }

}
