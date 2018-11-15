using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ticketish.Enums;

namespace Ticketish.Models
{
  [Table("tck_comments")]
  public class Comment : ITrackable
  {
    [Key]
    public long Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Content { get; set; }

    [Required]
    [EnumDataType(typeof(CommentOwner))]
    public CommentOwner Owner { get; set; }

    public Ticket Ticket { get; set; }
    public long TicketId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
    public long LastUpdatedBy { get; set; }
  }
}
