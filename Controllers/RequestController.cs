using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        // GET: api/Request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
        {
            return await _context.Requests.ToListAsync();
        }

        // GET: api/Request/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(long id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<Request>> PostTodoItem(Request item)
        {
            _context.Requests.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRequest), new { id = item.rid }, item);
        }

        private readonly RequestContext _context;

        public RequestController(RequestContext context)
        {
            _context = context;

            if (_context.Requests.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Requests.Add(new Request { name = "Item1" });
                _context.SaveChanges();
            }

        }
    }

}

