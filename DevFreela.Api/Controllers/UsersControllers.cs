using DevFreela.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers
{
    [Route("api/users")]
    public class UsersControllers : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById (int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel createUser)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, createUser);
        }

        //api/users/1/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel login)
        {
            return NoContent();
        }
    }
}
