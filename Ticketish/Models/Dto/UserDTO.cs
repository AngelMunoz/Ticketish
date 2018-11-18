using System;
using Ticketish.Enums;

namespace Ticketish.Models.Dto
{
  public class UserDTO
  {
    public long Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; }
    public UserType Type { get; set; }
  }
}
