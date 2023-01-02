using dataLayer.Models;
using dataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;     
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text.Json;

namespace backLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<SensorDataController> _logger;
        private readonly UserRepository _userRepository;

        public UserController(ILogger<SensorDataController> logger, IRepository<User> userRepository)
        {
            _logger = logger;
            _userRepository = (UserRepository)userRepository;
        }

        [HttpGet(Name = "GetUserList")]
        [Route("GetUserList")]
        public async Task<ActionResult<object>> GetUserList()
        {
            try
            {
                var users = _userRepository.GetItems();
                if (users.Count() == 0)
                    throw new Exception("Server has no data");
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }

        [HttpGet(Name = "Register")]
        [Route("Register")]
        public async Task<ActionResult> Register([FromForm] string userName, [FromForm] string password)
        {
            try
            {
                User user = new User{ UserName = userName, Password = password};
                _userRepository.AddItem(user);
                await Login(userName, password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet(Name = "IsAuthenticated")]
        [Route("IsAuthenticated")]
        public async Task<ActionResult<bool>> IsAuthenticated()
        {
            try
            {
                var user = this.HttpContext.User.Identity; 
                if (user is not null && user.IsAuthenticated)
                    return Ok(true);
                else 
                    return Ok(false);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet(Name = "Logout")]
        [Route("Logout")]
        public async Task<ActionResult> Logout()
        {
            try
            {
                await this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet(Name = "Login")]
        [Route("Login")]
        public async Task<ActionResult> Login([FromForm] string userName, [FromForm] string password)
        {
            try
            {
                var user = _userRepository.GetByUserCredentials(userName, password);
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.UserData, user.Password)}; 
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await this.HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(claimsIdentity));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}