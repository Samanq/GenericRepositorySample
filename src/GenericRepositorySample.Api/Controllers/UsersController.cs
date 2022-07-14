using Microsoft.AspNetCore.Mvc;
using GenericRepositorySample.Api.DataContexts;
using GenericRepositorySample.Api.Entities;
using GenericRepositorySample.Api.Repositories;
using GenericRepositorySample.Api.Repositories.Interfaces;

namespace GenericRepositorySample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(DataContext dataContext)
        {
            _userRepository = new UserRepository(dataContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await _userRepository.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            return Ok(user);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            await _userRepository.Add(user);

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Edit([FromBody] User user, long id)
        {
            if (id != user.Id) return BadRequest();

            await _userRepository.Edit(user);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _userRepository.Delete(id);

            return Ok();
        }
    }
}
