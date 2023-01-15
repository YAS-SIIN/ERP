global using Xunit;

using ERP.Entities.Context;
using Microsoft.EntityFrameworkCore;
using ERP.Api.Controllers.Admin;
using ERP.Common.Shared;
using ERP.Dtos.Admin;
using ERP.Dtos.Other;        
using ERP.Entities.UnitOfWork;
using ERP.Service.Admin;
using Microsoft.Extensions.Options;
using Moq;

private readonly MyDataBase? context;
private readonly ERP.Dtos.Other.ApplicationOptions testOption;
private readonly IOptions<ERP.Dtos.Other.ApplicationOptions> _iOptions;
private readonly Mock<ISecurity> _security;
private readonly JwtManager _jwtManager;
private readonly IUnitOfWork _unitOfWork;

DbContextOptions<MyDataBase> contextOptions;

testOption = new ERP.Dtos.Other.ApplicationOptions();
testOption.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB; UID=sa; Password=ABCabc123456;Database=ERP;";
