using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestOpenID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenidController : ControllerBase
    {
        // GET api/openid
        [HttpGet]
        [Authorize("read:messages")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "read:messages", "value2" , "value3"};
        }

        // GET api/openid/getPrivate
        [HttpGet]
        [Route("getPrivateScope")]
        [Authorize]
        public ActionResult<IEnumerable<string>> getPrivateScope()
        {
            return new string[] { "Private Scope", "value2", "value3" };
        }


        // GET api/openid/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/openid
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/openid/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/openid/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
