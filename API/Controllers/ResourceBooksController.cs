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
    [ApiController]
    [Route("api/[controller]")]
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

        // Optional: Add GET by id for CreatedAtAction reference
        [HttpGet("{id}")]
        public async Task<ActionResult<ResourceBook>> GetResourceBook(int id)
        {
            var resourceBook = await _context.ResourceBooks
                .Include(rb => rb.Resource)
                .FirstOrDefaultAsync(rb => rb.Id == id);

            if (resourceBook == null)
            {
                return NotFound();
            }

            return resourceBook;
        }

        /// <summary>
        /// //declare a method of type async Task<IActionResult> called CreateCar 
        /// that reads the car parameter from the body of the HTTP request. [FromBody] attribute can 
        /// be omitted if there is only one class parameter
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateResourceBook([FromBody] CreateResourceBookDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resource = new Resource
            {
                Title = dto.Title,
                ResourceTypeId = dto.ResourceTypeId,
                ResourceTopicId = dto.ResourceTopicId
            };
            // Add Resource to context to generate ResourceId
            _context.Resources.Add(resource);
            await _context.SaveChangesAsync();

            // Create ResourceBook entity with FK
            var resourceBook = new ResourceBook
            {
                Author = dto.Author,
                Pages = dto.Pages,
                Cost = dto.Cost,
                PublishDate = dto.PublishDate,
                ResourceId = resource.ResourceId
            };

            _context.ResourceBooks.Add(resourceBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetResourceBook), new { id = resourceBook.Id }, resourceBook);
        }
    }
}
