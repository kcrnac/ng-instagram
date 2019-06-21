using System.Security.Claims;
using System.Threading.Tasks;
using Instagram.Business.Interfaces;
using Instagram.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        [ServiceFilter(typeof(ModelValidationFilterAttribute))]
        public async Task<IActionResult> Get(string id)
        {
            string userId = id ?? User.FindFirst(ClaimTypes.Name).Value;
            var user = await _userService.GetUserById(userId);

            return Ok(new { user });
        }

        [HttpGet]
        [Route("GetByUsername")]
        [ServiceFilter(typeof(ModelValidationFilterAttribute))]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var user = await _userService.GetUserByUsername(username);

            return Ok(new { user });
        }
    }
}