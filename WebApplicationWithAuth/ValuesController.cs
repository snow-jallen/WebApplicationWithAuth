using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationWithAuth
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static List<string> myValues = new List<string>();

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return myValues;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return myValues[id];
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            myValues.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            myValues[id] = value;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            myValues.RemoveAt(id);
        }
    }
}
