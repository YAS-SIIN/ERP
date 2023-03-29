
using ERP.Api.GraphQL;
using ERP.Api.HubServices;
using ERP.Api.Middlewares;
using ERP.Dtos.Other;
using ERP.Entities.Context;
using ERP.Entities.UnitOfWork;

using HotChocolate.AspNetCore;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;

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

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

builder.Services.AddOptions<ApplicationOptions>().Bind(builder.Configuration.GetSection("ApplicationOptions"));

builder.Services.AddAuthentication(x => { x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; }).AddJwtBearer();

builder.Services.AddDbContext<MyDataBase>(options => options.UseSqlServer(builder.Configuration["ApplicationOptions:ConnectionString"]));
//builder.Services.AddDbContext<MyDataBase>(options => options.UseInMemoryDatabase("MyDB"));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

ERP.Service.DependencyResolver.Register(builder.Services);
ERP.Common.DependencyResolver.Register(builder.Services);

builder.Services.AddResponseCaching();

builder.Services.AddSignalR();
builder.Services.AddGraphQLServer().AddQueryType<EmployeeQuery>();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{                                                                   
//    var services = scope.ServiceProvider;
//    var _uw = services.GetRequiredService<IUnitOfWork>();

//    NewDataGenerator.InsertNewData(_uw);      
//}

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<AuthenticatorMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");

//app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
    RequestPath = new PathString("/Resources")
});

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endPoints =>
{
    endPoints.MapHub<TestHub>("/testhub");
    endPoints.MapGraphQL("/graphql","").WithOptions(new GraphQLServerOptions
    {
        EnableSchemaRequests = false
    });
    //endPoints.MapBananaCakePop("/ui").WithOptions(new GraphQLToolOptions
    //{
    //    GraphQLEndpoint = "/graphql"
    //});

});
app.MapControllers();

//app.MapGraphQL("/graphql", "");

app.Run();
