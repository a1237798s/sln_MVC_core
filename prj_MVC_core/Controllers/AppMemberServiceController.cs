using Microsoft.AspNetCore.Mvc;
using prj_MVC_core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace prj_MVC_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppMemberServiceController : ControllerBase
    {
        // GET: api/<AppMemberServiceController>
        [HttpGet]
        public IEnumerable<TCustomer> Get()
        {
            DbdemoContext db = new DbdemoContext();
            var datas =from t in db.TCustomers select t;

            return datas;
        }

        // GET api/<AppMemberServiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AppMemberServiceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AppMemberServiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppMemberServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
