using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserServices userServices = new UserServices();
        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<User> Get([FromQuery] string password, [FromQuery] string userName)
        {
            User user = userServices.GetUserByUsarNameAndPassword(userName, password);
            if (user != null)
                return Ok(user);
            return NoContent();

        }

        //// GET api/<UsersController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            userServices.addUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }

        [HttpPost("checkStrongPassword")]
        public ActionResult<User> Post([FromBody] string password)
        {
            int res = userServices.checkPassword(password);
            if (res > 2)
                return Ok(res);
            return NoContent();
        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User userUpdate)
        {
            userServices.update(id, userUpdate);
        }


        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
