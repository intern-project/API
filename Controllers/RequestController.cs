using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.Cors;
using System.IO;
using System;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers {

    [Route ("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    
    public class RequestController : Controller {
        private readonly RequestRepository requestRepository;
        public RequestController () {
            requestRepository = new RequestRepository ();
        }

        // GET: api/values
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<Request> Get () {
            return requestRepository.GetAll ();
        }

        //PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Request request){
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
        // file upload
        [HttpPost("upload"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("StaticFiles", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
} 
    }

}