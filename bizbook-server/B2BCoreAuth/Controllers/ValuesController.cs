using System;
using System.Collections.Generic;
using System.Linq;
using B2BCoreApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B2BCoreApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private SecurityDbContext _db;
        public ValuesController(SecurityDbContext db)
        {
            _db = db;
        }
        // GET api/values
        //        [Authorize]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { _db.Users.Count(x => x.IsActive).ToString(), DateTime.Now.ToString() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value - " + id;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(string value)
        {
            return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
