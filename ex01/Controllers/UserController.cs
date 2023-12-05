using AutoMapper;
using DTO;
using Entities;

using Microsoft.AspNetCore.Mvc;
using repository;
using servies;
using System.Diagnostics;
using System.Text.Json;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUserServies _UserServies;
        private readonly ILogger _logger;

        public UserController(IUserServies UserServies,IMapper mapper,ILogger<UserController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _UserServies = UserServies;
        }
        [Route("login")]
        // GET: api/<UserController>login
        [HttpPost]
        public async Task<ActionResult<User>> Get([FromBody] UserLoginDTO loginDTO)
        {
            var userName = loginDTO.Email;
            var password = loginDTO.Password;
            User user = await _UserServies.getUserByUserNameAndPassword(userName, password);
            if (user == null)
                return NoContent();
            
            return Ok(user);
 
        }


        // POST api/<UserController>
        [HttpPost]
        public async Task<CreatedAtActionResult> Post([FromBody] UserDTO userDTO)
        {
             User user=_mapper.Map<UserDTO,User>(userDTO);
                 await _UserServies.CreateNewUser(user);
            _logger.LogInformation($"new user crated {user}");
            return  CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }
        [HttpPost("check")]
        public async Task<int> Check([FromBody] string password)
        {
            if (password != "")
            { 
                return await _UserServies.check(password);
            }
            return -1;

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
          await  _UserServies.Put(id, userToUpdate);


        }
        
    }
}
