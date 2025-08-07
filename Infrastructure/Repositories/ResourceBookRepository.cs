using WebApplication2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Domain.IRepositories;
using WebApplication2.Infrastructure.Persistence;

namespace WebApplication2.Infrastructure.Repositories
{
    public class ResourceBookRepository : IResourceBookRepository
    {
        private readonly ApplicationDbContext _context;

        public ResourceBookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        //public async Task<ResourceBook> GetBookAsync(int Id)
        //{
        //    return await _context.Books
        //                         .FirstOrDefaultAsync(b => b.Id == Id);
        //}

        public async Task<List<Book>> GetBooksByUserAsync(int userId)
        {
            return await _context.Books
                                 .Where(b => b.Id == userId)
                                 .ToListAsync();
        }

        public async Task UpdateBookAsync(Book ResourceBook)
        {
            _context.Books.Update(ResourceBook);
            await _context.SaveChangesAsync();
        }

        public async Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

    }
}
