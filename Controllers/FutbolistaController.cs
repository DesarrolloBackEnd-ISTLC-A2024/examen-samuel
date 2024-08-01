using examen_samuel.Comunes;
using examen_samuel.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace examen_samuel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutbolistaController : ControllerBase
    {
        // GET: api/<FutbolistaController>
        [HttpGet]
        public List<Futbolista> Get()
        {
            return ConexionDB.GetFutbolistas();
        }

        // GET api/<FutbolistaController>/5
        [HttpGet("{cedula}")]
        public Futbolista Get(string cedula)
        {
            return ConexionDB.GetFutbolista(cedula);
        }

        // POST api/<FutbolistaController>
        [HttpPost]
        public void Post([FromBody] Futbolista objJugador)
        {
            ConexionDB.PostFutbolista(objJugador);
        }

        // PUT api/<FutbolistaController>/5
        [HttpPut("{cedula}")]
        public void Put(string cedula, [FromBody] Futbolista objJugador)
        {
            ConexionDB.PutFutbolista(cedula, objJugador);
        }

        // DELETE api/<FutbolistaController>/5
        [HttpDelete("{cedula}")]
        public void Delete(string cedula)
        {
            ConexionDB.DeleteFutbolista(cedula);
        }
    }
}
