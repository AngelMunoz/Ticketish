using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketish.Models
{
  [Table("tck_attachments")]
  public class Attachment : ITrackable
  {
    [Key]
    public long Id { get; set; }

    [MaxLength(100)]
    [Required]
    public string Name { get; set; }

    [MaxLength(255)]
    [Required]
    public string Path { get; set; }

    [MaxLength(255)]
    public string PublicUrl { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
    public long LastUpdatedBy { get; set; }

  }
}
