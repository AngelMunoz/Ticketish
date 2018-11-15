using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ticketish.Services
{
  public interface IService<T>
  {
    Task<List<T>> FindAsync();
    Task<T> FindOneAsync(long id);
    Task<T> CreateAsync(T payload);
    Task UpdateAsync(long id, T payload);
    Task<T> DestroyAsync(long id);
  }
}
