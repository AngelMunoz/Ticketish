using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketish.Models
{
  [Table("tck_roles")]
  public class Role : ITrackable
  {
    [Key]
    public long Id { get; set; }

    [Required]
    [MaxLength(40)]
    public string Name { get; set; }

    [MaxLength(100)]
    public string Description { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
    public long LastUpdatedBy { get; set; }
  }
}