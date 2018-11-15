using System;

namespace Ticketish.Models
{
  public interface ITrackable
  {
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
    long LastUpdatedBy { get; set; }
  }
}
