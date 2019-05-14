using System.Threading.Tasks;
using Instagram.Business.Interfaces;
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
        public async Task<IActionResult> Post(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            var token = await _userService.Login(model.Username, model.Password);

            return Ok(new { token });
        }
    }
}