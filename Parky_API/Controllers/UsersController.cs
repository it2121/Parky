using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parky_API.Models;
using Parky_API.Repository.IRepository;

namespace Parky_API.Controllers
{

    [Authurized]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;


        }

        [AllowAnonymous]
         [HttpPost("authenticate")]


         public IActionResult Authenticate([FromBody] User model)
        {


            var user = _userRepository.Authenticate(model.Username, model.Password);

            if (user == null) {
            
            return BadRequest(new { message = "username or password is incorrect"});
            
            }


            return Ok(user);

        }
    }
}
