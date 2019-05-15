using System.Threading.Tasks;
using Instagram.Business.Interfaces;
using Instagram.WebApi.Extensions;
using Instagram.WebApi.Mappers;
using Instagram.WebApi.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelValidationFilterAttribute))]
        public async Task<object> Post(RegisterModel model)
        {
            var result = await _userService.Register(model.MapToBussinesModel());

            return Ok(result);
        }
    }
}