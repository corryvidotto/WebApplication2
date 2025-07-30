using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.API.Controllers;
using WebApplication2.Application.DTOs;
using WebApplication2.Domain.Entities;
using WebApplication2.Infrastructure.Persistence;


namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceBooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResourceBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/resourcebooks plus data from the related table Resource
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceBook>>> GetAllBooksAsync()
        {
            var resourceBooks = await _context.ResourceBooks
            .Include(rb => rb.Resource) //when returning rb (ResourceBooks, also retrieve the related (FK) Resource entity for each ResourceBook
            .Select(rb => new ResourceBookDTO
            {
                Author = rb.Author,
                Resource = new ResourceDTO
                {
                    //null-forgiving operator  [!]   in C#. It tells the compiler: "I know that rb.Resource might look like it could be null, but I’m telling you it won’t be null at runtime—so stop giving me a warning."    
                    Title = rb.Resource!.Title
                }
            })
            .ToListAsync();
            return Ok(resourceBooks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResourceBook>> GetResourceBookById(int id)
        {
            var resourceBook = await _context.ResourceBooks
                .Include(gr => gr.Resource)  // Include related Books
                .FirstOrDefaultAsync(gr => gr.Id == id);

            if (resourceBook == null)
            {
                return NotFound();
            }
            return Ok(resourceBook);
        }
    }
}
