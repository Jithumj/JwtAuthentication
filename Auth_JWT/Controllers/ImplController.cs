using Auth_JWT.Implementation;
using Auth_JWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImplController : ControllerBase
    {
        private readonly IUserImpl _userImpl;

        public ImplController(IUserImpl userImpl)
        {
            _userImpl = userImpl;
        }

        [HttpPost("Login")]
        [AllowAnonymous]

        public IActionResult Login(UserModel user)
        {
            var token=_userImpl.Login(user);
            if(token == null || token==string.Empty) 
            {
                return BadRequest(new { message = "username or pasword is incorrect" });

            
            }
            return Ok(token);
        }
    }
}
