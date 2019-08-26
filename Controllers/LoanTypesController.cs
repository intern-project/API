using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanTypesController : Controller
    {
        private readonly LoanTypeRepository loanTypeRepository;

        public LoanTypesController() {
            loanTypeRepository = new LoanTypeRepository ();
        }

        // GET api/
        [HttpGet]
        public  IEnumerable<LoanType> Get()
        {
            return LoanTypeRepository.GetAll();

        }    
        // GET api/LoanTypes/5
        // [HttpGet("{id}")]
        // public ActionResult<IEnumerable<LoanType>> Get(int id)
        // {
        //     return LoanTypeRepository.GetById(id);
        // }

        // POST api/LoanTypes
        [HttpPost]
        public void Post([FromBody] LoanType loanType)
        {
            if (ModelState.IsValid) 
                LoanTypeRepository.Add(loanType);
        }

        // PUT api/LoanTypes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] LoanType loanType)
        {
            loanType.id = id;
            if (ModelState.IsValid) 
                LoanTypeRepository.Update(loanType);
        }

        // DELETE api/LoanTypes/5
    //     [HttpDelete("{id}")]
    //     public void Delete(int id)
    //     {
    //     }
    }
}
