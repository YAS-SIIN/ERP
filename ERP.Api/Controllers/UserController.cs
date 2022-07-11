using ERP.Models.Admin;
using ERP.Service.Crud;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ICrudService<AdminUser> _adminUserService;             
        public UserController(ILogger<UserController> logger, ICrudService<AdminUser> adminUserService)
        {
            _logger = logger;
            _adminUserService = adminUserService;
        }

        [HttpGet]
        public IEnumerable<AdminUser> Get()
        {
            _logger.LogInformation($"ControllerName: {ControllerContext.RouteData.Values["action"]} - ActionName: {ControllerContext.RouteData.Values["action"]}");
            return _adminUserService.GetAll().Take(100);
        }

    }
}
