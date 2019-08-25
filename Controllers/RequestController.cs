using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {

    [Route ("api/[controller]")]
    [ApiController]
    public class RequestController : Controller {
        private readonly RequestRepository requestRepository;
        public RequestController () {
            requestRepository = new RequestRepository ();
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Request> Get () {
            return requestRepository.GetAll ();
        }

        //PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]Request request){
            request.rid = id;
            if (ModelState.IsValid) {
                RequestRepository.Update(request);
            }
        }

        // // GET: api/Request/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Request>> GetRequest(long id)
        // {
        //     var request = await _context.Request.FindAsync(id);

        //     if (request == null)
        //     {
        //         return NotFound();
        //     }

        //     return request;
        // }

        //POST: api/Request
        [HttpPost]
        public void Post ([FromBody] Request request) {
            if (ModelState.IsValid)
                RequestRepository.Add(request);
        }

        // private readonly RequestContext _context;

        // public RequestController(RequestContext context)
        // {
        //     _context = context;

        //     if (_context.Request.Count() == 0)
        //     {
        //         // Create a new TodoItem if collection is empty,
        //         // which means you can't delete all TodoItems.
        //         _context.Request.Add(new Request { name = "Item1" });
        //         _context.SaveChanges();
        //     }

        // }
    }

}