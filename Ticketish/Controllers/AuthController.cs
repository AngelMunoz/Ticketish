using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ticketish.Models;
using Ticketish.Models.Dto;
using Ticketish.Services;
using Ticketish.Utils;

namespace Ticketish.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly UserService _userService;
    private readonly IConfiguration _config;

    public AuthController(UserService userservice, IConfiguration configuration)
    {
      _userService = userservice;
      _config = configuration;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] User user)
    {

      user.Password = HashPassword(user.Password);
      try
      {
        await _userService.CreateAsync(user);
      }
      catch (DbUpdateException updateEx)
      {
        if (updateEx.InnerException.Message.ToLower().Contains("duplicate"))
        {
          return BadRequest(updateEx.InnerException.Message);
        }
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
      UserDTO usr = new UserDTO();
      Copier.CopyPropertiesTo(user, usr);
      return CreatedAtAction("SignUp", usr);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO payload)
    {
      var count = await _userService.Count();
      if (count <= 0)
      {
        return NotFound();
      }
      User user;
      try
      {
        user = await _userService.FindOneAsync(payload.Email);
      }
      catch (ArgumentException)
      {
        return NotFound();
      }

      if (!PasswordsMatch(user.Password, payload.Password))
      {
        return BadRequest();
      }

      var u = new UserDTO();

      Copier.CopyPropertiesTo(user, u);

      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("JwtSecret")));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
      var header = new JwtHeader(credentials);
      //Some PayLoad that contain information about the  customer
      var date = DateTime.UtcNow;
      var descriptor = new SecurityTokenDescriptor()
      {
        SigningCredentials = credentials,
        IssuedAt = date,
        Expires = date.AddDays(1),
        Subject = new ClaimsIdentity(new[]
        {
          new Claim(ClaimTypes.Name, u.Name),
          new Claim(ClaimTypes.NameIdentifier, u.Id.ToString()),
          new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(u))
        })
      };
      var handler = new JwtSecurityTokenHandler();
      // Token to String so you can use it in your client
      var token = handler.CreateToken(descriptor);
      var tokenString = handler.WriteToken(token);
      return new JsonResult(new Dictionary<string, object>() { { "user", u }, { "token", tokenString } });
    }

    // Private methods

    private static bool PasswordsMatch(string fromUser, string fromRequest)
    {
      /* Fetch the stored value */
      string savedPasswordHash = fromUser;
      /* Extract the bytes */
      byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
      /* Get the salt */
      byte[] salt = new byte[16];
      Array.Copy(hashBytes, 0, salt, 0, 16);
      /* Compute the hash on the password the user entered */
      var pbkdf2 = new Rfc2898DeriveBytes(fromRequest, salt, 10000);
      byte[] hash = pbkdf2.GetBytes(20);
      /* Compare the results */
      for (int i = 0; i < 20; i++)
      {
        if (hashBytes[i + 16] != hash[i])
        {
          return false;
        }
      }
      return true;
    }

    public static string HashPassword(string password)
    {
      byte[] salt;
      new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
      var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
      byte[] hash = pbkdf2.GetBytes(20);
      byte[] hashBytes = new byte[36];
      Array.Copy(salt, 0, hashBytes, 0, 16);
      Array.Copy(hash, 0, hashBytes, 16, 20);
      return Convert.ToBase64String(hashBytes);
    }

  }
}