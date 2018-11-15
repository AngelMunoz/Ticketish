using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketish.Models;

namespace Ticketish.Services
{
  public class UserService : IService<User>
  {
    private readonly TckContext _context;

    public UserService(TckContext context)
    {
      _context = context;
    }

    public async Task<User> CreateAsync(User payload)
    {
      var user = _context.Add(payload);
      await _context.SaveChangesAsync();
      return user.Entity;
    }

    public async Task<long> Count()
    {
      return await _context.Users.CountAsync();
    }

    public Task<User> DestroyAsync(long id)
    {
      throw new NotImplementedException();
    }

    public Task<List<User>> FindAsync()
    {
      throw new NotImplementedException();
    }

    public async Task<User> FindOneAsync(long id)
    {
      var user = await _context.Users.FindAsync(id);
      if (user == null) { throw new ArgumentException(); }
      return user;
    }

    public async Task<User> FindOneAsync(string email)
    {
      var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
      if (user == null) { throw new ArgumentException(); }
      return user;
    }

    public Task UpdateAsync(long id, User payload)
    {
      throw new NotImplementedException();
    }
  }
}
