using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    private readonly IConfiguration _config;

    public UsersController(UserService service, IConfiguration config)
    {
      _service = service;
      _config = config;
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

    [HttpPost("add")]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      var claim = HttpContext.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
      var sender = await _service.FindOneAsync(long.Parse(claim.Value));
      var role = new Role
      {
        Name = "ROOT"
      };
      if (sender.Roles != null && sender.Roles.Contains(role))
      {
        Console.WriteLine("Yay!");
      }
      else
      {
        Console.WriteLine("No Yay Yay!");
      }

      await _service.CreateAsync(user);

      return NoContent();
    }

  }
}