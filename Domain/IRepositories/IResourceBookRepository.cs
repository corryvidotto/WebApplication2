using Microsoft.EntityFrameworkCore;
using WebApplication2.Domain.Entities;

namespace WebApplication2.Domain.IRepositories
   
{
        public interface IResourceBookRepository
        {
        //Task<IEnumerable<ResourceBook>> GetBookAsync(int bookId);
            Task<IEnumerable<ResourceBook>> GetAllBooksAsync();
            Task<List<ResourceBook>> GetBooksByUserAsync(int userId);
            Task UpdateBookAsync(ResourceBook book);
            Task AddBookAsync(ResourceBook book);
        }
}
