using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptingupApiClient.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CryptoController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }


        // GET: api/<CryptoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("GetCoinbase")]
        public async Task<IActionResult> GetCoinbase()
        {
            HttpClient client = httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://www.cryptingup.com/api/exchanges/COINBASE");
            var content = await result.Content.ReadAsStringAsync();

            return Ok(content);
        }

        // GET api/<CryptoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CryptoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CryptoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CryptoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
