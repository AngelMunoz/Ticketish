using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ticketish.Enums;

namespace Ticketish.Models
{
  [Table("tck_tickets")]
  public class Ticket : ITrackable
  {

    [Key]
    public long Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [Required]
    [MaxLength(200)]
    public string Content { get; set; }

    [Required]
    [EnumDataType(typeof(TicketStatus))]
    public TicketStatus Status { get; set; }

    public DateTime? ClosedAt { get; set; }

    /// Relationships

    public User Customer { get; set; }
    public long CustomerId { get; set; }

    public User Representative { get; set; }
    public long RepresentativeId { get; set; }

    public Product Product { get; set; }
    public long ProductId { get; set; }


    public List<Comment> Comments { get; set; }
    public List<Attachment> Attachments { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
    public long LastUpdatedBy { get; set; }
  }
}
