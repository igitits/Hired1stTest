using Hired1stTest.DTO;
using Hired1stTest.Models;
using Hired1stTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hired1stTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUser _userService;

        public UserController(IUser userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult Index()
        {
            var a = _userService.GetAllUsers();
            if (a == null)
            {
                return NotFound();
            }

            return Ok(a);
        }

        [HttpGet]
        [Route("GetUserByEmail")]
        public IActionResult GetUserByEmail(string email)
        {
            var user = _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult Register(RegisterDTO user)
        {
            bool rs = _userService.CreateUser(user);
            if (rs == false)
            {
                return BadRequest("Registration failed");
            }
            else return Ok("Added User: " + rs);
        }

        [HttpPut]
        [Route("EditUser")]
        public IActionResult Edit(User user)
        {
            int rs = _userService.UpdateUser(user);
            if (rs <= 0)
            {
                return BadRequest("Failed");
            }
            else
                return Ok("Updated!");
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult Delete(string email)
        {
            int rs = _userService.DeleteUser(email);
            if (rs <= 0)
            {
                return BadRequest("Failed");
            }
            else
                return Ok("Deleted!");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser(LoginDTO cred)
        {
            var user = _userService.LoginUser(cred);
            if (user == null) { return NotFound(); }
            return Ok(user);
        }
    }
}
