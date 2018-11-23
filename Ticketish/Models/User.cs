using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ticketish.Enums;

namespace Ticketish.Models
{
  [Table("tck_users")]
  public class User : ITrackable
  {
    [Key]
    public long Id { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    [StringLength(80, MinimumLength = 4)]
    public string Name { get; set; }

    [Required]
    [StringLength(80, MinimumLength = 4)]
    public string LastName { get; set; }

    [Required]
    [EnumDataType(typeof(UserType))]
    public UserType Type { get; set; }

    public List<UserRole> UserRoles { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
    public long LastUpdatedBy { get; set; }
  }
}
