using Microsoft.AspNetCore.Http;
using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutinaController : ControllerBase
    {
        private IRutinaDAL rutinaDAL;

        RutinaModel Convertir(Rutina rutina)
        {

            return new RutinaModel
            {
                IdRutina = rutina.IdRutina,
                NombreRutina = rutina.NombreRutina,
                IdCliente = rutina.IdCliente,
                IdUsuario = rutina.IdUsuario,
            };

        }

        Rutina Convertir(RutinaModel rutina)
        {

            return new Rutina
            {
                IdRutina = rutina.IdRutina,
                NombreRutina = rutina.NombreRutina,
                IdCliente = rutina.IdCliente,
                IdUsuario = rutina.IdUsuario,
            };

        }

        public RutinaController()
        {
            rutinaDAL = new RutinaDALImpl();

        }

        // GET: api/<RutinaController>
        [HttpGet]
        public JsonResult Get()
        {
            List<Rutina> rutinas = rutinaDAL.GetAll().ToList();
            List<RutinaModel> result = new List<RutinaModel>();
            foreach (Rutina rutina in rutinas)
            {
                result.Add(Convertir(rutina));
            }
            return new JsonResult(result);
        }

        // GET api/<RutinaController>/{id}
        [HttpGet("{id}")]
        public JsonResult GetOne(int id)
        {
            Rutina rutina = rutinaDAL.Get(id);

            return new JsonResult(Convertir(rutina));
        }

        // POST api/<RutinaController>
        [HttpPost]
        public JsonResult Post([FromBody] RutinaModel rutina)
        {
            rutinaDAL.Add(Convertir(rutina));

            return new JsonResult(Convertir(rutina));
        }

        // PUT api/<RutinaController>/{id}
        [HttpPut]
        public JsonResult Put([FromBody] Rutina rutina)
        {
            rutinaDAL.Update(rutina);

            return new JsonResult(Convertir(rutina));
        }
        // DELETE api/<RutinaController>/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Rutina rutina = new Rutina()
            {
                IdRutina = id
            };
            rutinaDAL.Remove(rutina);
        }
    }
}