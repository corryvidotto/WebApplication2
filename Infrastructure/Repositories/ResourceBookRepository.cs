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

        public async Task<IEnumerable<ResourceBook>> GetAllBooksAsync()
        {
            return await _context.ResourceBooks.ToListAsync();
        }

        //public async Task<ResourceBook> GetBookAsync(int Id)
        //{
        //    return await _context.ResourceBooks
        //                         .FirstOrDefaultAsync(b => b.Id == Id);
        //}

        public async Task<List<ResourceBook>> GetBooksByUserAsync(int userId)
        {
            return await _context.ResourceBooks
                                 .Where(b => b.Id == userId)
                                 .ToListAsync();
        }

        public async Task UpdateBookAsync(ResourceBook ResourceBook)
        {
            _context.ResourceBooks.Update(ResourceBook);
            await _context.SaveChangesAsync();
        }

        public async Task AddBookAsync(ResourceBook book)
        {
            _context.ResourceBooks.Add(book);
            await _context.SaveChangesAsync();
        }

    }
}
