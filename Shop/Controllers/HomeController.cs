using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shop.Models;
using Shop.Properties;
using Shop.Repositories;
using Shop.Services;

namespace Shop.Controllers
{
    [Route("v1/account")]
    public class HomeController : ControllerBase 
    {

        private readonly TokenService _tokenService;
        private readonly UserRepository _userRepository;

        public HomeController(TokenService tokenService, UserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = _userRepository.Get(model.UserName, model.Password);
            if (user == null)
                return NotFound(new {message = "User or password not valid"});
            var token = _tokenService.GenerateToken(user);

            return new { user = user, token = token };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anonymous";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Authenticated - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => String.Format("Employee");

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => String.Format("Manager");
    }
}
