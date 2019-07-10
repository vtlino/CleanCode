using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // GET api/values
        [HttpGet("teste")]
        public async Task<ActionResult<string>> GetAsync(string siafiCode)
        {

            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.Timeout = new TimeSpan(4, 0, 0);

                var resposta = await client.GetAsync($"http://www.transparencia.gov.br/api-de-dados/orgaos-siafi?codigo={siafiCode}&pagina=1");
                var answer = resposta.Content.ReadAsStringAsync().Result;
                //var retorno = JsonConvert.DeserializeObject<List<int>>(listaGrandeCentroId);
                return answer;
            }
            //return new string[] { "value1", "value2" };
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
