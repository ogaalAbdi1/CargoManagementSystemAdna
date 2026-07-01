using CargoManagementSytem.Data;
using CargoManagementSytem.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CargoManagementSytem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        UsersData data = new UsersData();


        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(data.GetUsers());
        }

        //
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = data.GetUserById(id);

            if (user == null)
            {
                return NotFound($"User ID {id} ma jiro.");
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult InsertUser(Users user)
        {
            data.InsertUser(user);
            return Ok("User inserted successfully.");
        }

        [HttpPut]
        public IActionResult UpdateUser(Users user)
        {
            data.UpdateUser(user);
            return Ok("User updated successfully.");
        }

        [HttpPost("login")]
        public IActionResult Login(Users user)
        {
            var result = data.Login(user.UserName, user.Password);

            if (result == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(result);
        }

    }
}
