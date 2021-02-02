using Microsoft.AspNetCore.Mvc;
using Ratings.DTO;
using Ratings.Infra;
using Ratings.Models;
using Ratings.Repositories.Users;
using System;
using System.Collections.Generic;

namespace Ratings.Controllers
{
    [ApiController]
    [Route("users")]

    public class UsersController : ControllerBase
    {
        private IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var users = _repository.GetAll();
                var parsedUsers = new List<ReadUserDTO> { };

                foreach(User user in users)
                {
                    var parsedUser = new ReadUserDTO { Id = user.Id, Name = user.Name };

                    parsedUsers.Add(parsedUser);
                }

                return Ok(new SuccessActionResult<IEnumerable<ReadUserDTO>>(parsedUsers));
            }
            catch (Exception exception)
            {
                return StatusCode(500, new ErrorActionResult(500, exception.Message));
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserDTO user)
        {
            try
            {
                var userToBeCreated = new User(user.Name);
                int id = _repository.Create(userToBeCreated);

                return Ok(new SuccessActionResult<object>(new { userId = id }));
            }
            catch (ArgumentException exception)
            {
                return BadRequest(new ErrorActionResult(400, exception.Message));
            }
            catch (Exception exception)
            {
                return StatusCode(500, new ErrorActionResult(500, exception.Message));
            }
        }
    }
}
