using System.Threading.Tasks;
using Instagram.Business.Interfaces;
using Instagram.WebApi.Extensions;
using Instagram.WebApi.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelValidationFilterAttribute))]
        public async Task<IActionResult> Post(LoginModel model)
        {
            var token = await _userService.Login(model.Username, model.Password);
            var user = await _userService.GetUserByUsername(model.Username);

            return Ok(new { token, user });
        }
    }
}