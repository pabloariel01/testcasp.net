using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testappdotnet.Data;

namespace testappdotnet.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _contexts;

        public ValuesController(DataContext context)
        {
            _contexts = context;
        }
        // GET: api/Values
        [HttpGet]
        public IActionResult GetValues()
        {
            var values = _contexts.Values.ToList();

            return Ok(values);
        }

        //overrides the authenitcate
        [AllowAnonymous]
        // GET: api/Values/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetValue(int id)
        {
            var value = _contexts.Values.FirstOrDefault(x=> x.Id==id);
            return Ok(value);
        }

        // POST: api/Values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
