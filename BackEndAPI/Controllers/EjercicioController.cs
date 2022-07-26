using Microsoft.AspNetCore.Http;
using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjercicioController : ControllerBase
    {
        private IEjercicioDAL ejercicioDAL;

        EjercicioModel Convertir(Ejercicio ejercicio)
        {

            return new EjercicioModel
            {
                IdEjercicio = ejercicio.IdEjercicio,
                NombreEjercicio = ejercicio.NombreEjercicio,
                Descripcion = ejercicio.Descripcion,
            };

        }

        Ejercicio Convertir(EjercicioModel ejercicio)
        {

            return new Ejercicio
            {
                IdEjercicio = ejercicio.IdEjercicio,
                NombreEjercicio = ejercicio.NombreEjercicio,
                Descripcion = ejercicio.Descripcion,
            };

        }

        public EjercicioController()
        {
            ejercicioDAL = new EjercicioDALImpl();

        }

        // GET: api/<EjercicioController>
        [HttpGet]
        public JsonResult Get()
        {
            List<Ejercicio> ejercicios = ejercicioDAL.GetAll().ToList();
            List<EjercicioModel> result = new List<EjercicioModel>();
            foreach (Ejercicio ejercicio in ejercicios)
            {
                result.Add(Convertir(ejercicio));
            }
            return new JsonResult(result);
        }

        // GET api/<EjercicioController>/{id}
        [HttpGet("{id}")]
        public JsonResult GetOne(int id)
        {
            Ejercicio ejercicio = ejercicioDAL.Get(id);

            return new JsonResult(Convertir(ejercicio));
        }

        // POST api/<EjercicioController>
        [HttpPost]
        public JsonResult Post([FromBody] EjercicioModel ejercicio)
        {
            ejercicioDAL.Add(Convertir(ejercicio));

            return new JsonResult(Convertir(ejercicio));
        }

        // PUT api/<EjercicioController>/{id}
        [HttpPut]
        public JsonResult Put([FromBody] Ejercicio ejercicio)
        {
            ejercicioDAL.Update(ejercicio);

            return new JsonResult(Convertir(ejercicio));
        }
        // DELETE api/<EjercicioController>/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Ejercicio ejercicio = new Ejercicio()
            {
                IdEjercicio = id
            };
            ejercicioDAL.Remove(ejercicio);
        }
    }
}