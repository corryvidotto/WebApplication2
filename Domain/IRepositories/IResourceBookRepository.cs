using Microsoft.EntityFrameworkCore;
using WebApplication2.Domain.Entities;

namespace WebApplication2.Domain.IRepositories
   
{
        public interface IResourceBookRepository
        {
        //Task<IEnumerable<ResourceBook>> GetBookAsync(int bookId);
            Task<IEnumerable<Book>> GetAllBooksAsync();
            Task<List<Book>> GetBooksByUserAsync(int userId);
            Task UpdateBookAsync(Book book);
            Task AddBookAsync(Book book);
        }
}
