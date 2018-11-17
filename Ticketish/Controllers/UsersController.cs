using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketish.Models;
using Ticketish.Models.Dto;
using Ticketish.Services;
using Ticketish.Utils;

namespace Ticketish.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly UserService _service;

    public UsersController(UserService service)
    {
      _service = service;
    }

    // GET: api/Users
    [HttpGet]
    public async Task<IEnumerable<UserDTO>> GetUsers()
    {
      var users = await _service.FindAsync();
      return users.Select(user =>
      {
        var dto = new UserDTO();
        Copier.CopyPropertiesTo(user, dto);
        return dto;
      });
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser([FromRoute] long id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var user = await _service.FindOneAsync(id);

      if (user == null)
      {
        return NotFound();
      }

      return Ok(user);
    }

    // PUT: api/Users/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser([FromRoute] long id, [FromBody] User user)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != user.Id)
      {
        return BadRequest();
      }

      await _service.UpdateAsync(user.Id, user);

      return NoContent();
    }

  }
}