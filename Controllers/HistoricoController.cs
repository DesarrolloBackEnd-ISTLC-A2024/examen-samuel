using examen_samuel.Comunes;
using examen_samuel.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace examen_samuel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoController : ControllerBase
    {
        // GET: api/<HistoricoEquiposController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HistoricoEquiposController>/5
        [HttpGet("{cedula}")]
        public List<Historico> Get(string cedula)
        {
            return ConexionDB.GetHistorico(cedula);
        }

        // POST api/<HistoricoEquiposController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HistoricoEquiposController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HistoricoEquiposController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
