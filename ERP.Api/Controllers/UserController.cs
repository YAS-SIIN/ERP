using ERP.Dtos.Admin;
using ERP.Models.Admin;
using ERP.Service.Crud;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        public IConfiguration _configuration;
        private readonly ICrudService<AdminUser> _adminUserService;             
        public UserController(ILogger<UserController> logger, IConfiguration config, ICrudService<AdminUser> adminUserService)
        {
            _logger = logger;
            _configuration = config;
            _adminUserService = adminUserService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {                                                  
            return Ok(await _adminUserService.GetAllAsync());
        }

        [HttpPost, Route("[action]")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto User)
        {
            _logger.LogInformation($"ControllerName: {ControllerContext.RouteData.Values["action"]} - ActionName: {ControllerContext.RouteData.Values["action"]}");
            var loginUser =await  _adminUserService.GetAsync(x => x.UserName == User.UserName && x.PassWord == User.PassWord && x.Status == 1);
            if (loginUser != null)
            {
                //create claims details based on the user information
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserName", loginUser.UserName),   
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                return  Ok(new JwtSecurityTokenHandler().WriteToken(token));  
            } else
            {
                return BadRequest(HttpStatusCode.NonAuthoritativeInformation);
            }                                  
        }

    }
}
