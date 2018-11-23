using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketish.Models
{
  [Table("tck_user_role")]
  public class UserRole
  {
    [Key]
    public long Id { get; set; }
    public User User { get; set; }
    public long UserId { get; set; }

    public Role Role { get; set; }
    public long RoleId { get; set; }
  }
}