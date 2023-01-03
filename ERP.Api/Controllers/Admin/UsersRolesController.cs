using ERP.Api.Middlewares;
using ERP.Dtos.Admin;
using ERP.Dtos.Exceptions;
using ERP.Models.Admin;
using ERP.Service.Admin;
using ERP.Service.Crud;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using static ERP.Common.Enums.TypeEnum;

namespace ERP.Api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersRolesController : ApiControllerBase
    {
        private readonly IUsersRolesService _usersRolesService;
        public UsersRolesController(IUsersRolesService usersRolesService)
        {
            _usersRolesService = usersRolesService;

        }

        [HttpPost, Route("[action]")]
        [Authorize(Role = "UsersRoles")]
        public async Task<ActionResult<ApiResultViewModel<dynamic>>> GetAsync(int UserId)
        {
            var result =await _usersRolesService.GetRolesByUserAsync(UserId);
                                      
            return OkData(result);
        }

        [HttpPost, Route("[action]")]
        [Authorize(Role = "UsersRoles")]
        public async Task<ActionResult<ApiResultViewModel<AdminRole>>> InsertUpdateAsync([FromBody] UserRoleDto model)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _usersRolesService.InsertUpdateUserRoleAsync(model);

            return OkData(model);
        }
    }
}
