using ERP.Api.Middlewares;
using ERP.Dtos.Other;
using ERP.Entities.Context;
using ERP.Entities.GenericRepository;
using ERP.Entities.UnitOfWork;
using ERP.Framework;
using ERP.Models.Admin;
using ERP.Service.Crud;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("X-Pagination"));
});

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
                    
builder.Services.AddOptions<ApplicationOptions>().Bind(builder.Configuration.GetSection("ApplicationOptions"));

builder.Services.AddAuthentication(x => { x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; }).AddJwtBearer();

builder.Services.AddDbContext<MyDataBase>(options => options.UseSqlServer(builder.Configuration["ApplicationOptions:ConnectionString"]));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

ERP.Service.DependencyResolver.Register(builder.Services);
ERP.Common.DependencyResolver.Register(builder.Services);


builder.Services.AddResponseCaching();
 

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<AuthenticatorMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
