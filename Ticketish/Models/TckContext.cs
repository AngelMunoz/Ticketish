using Microsoft.EntityFrameworkCore;

namespace Ticketish.Models
{
  public class TckContext : DbContext
  {

    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<User> Users { get; set; }

    public TckContext(DbContextOptions<TckContext> options) : base(options) { }
  }
}
