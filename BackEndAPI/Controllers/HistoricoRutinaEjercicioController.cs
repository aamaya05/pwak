using Microsoft.AspNetCore.Http;
using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoRutinaEjercicioController : ControllerBase
    {
        private IHistoricoRutinaEjerDAL rutinaEjerDAL;

        HistoricoRutinaEjercicioModel Convertir(HistoricoRutinaEjer rutinaEjer)
        {

            return new HistoricoRutinaEjercicioModel
            {
                IdHisRutEjer = rutinaEjer.IdHisRutEjer,
                IdHistRutina = rutinaEjer.IdHistRutina,
                IdEjercicio = rutinaEjer.IdEjercicio,
                Repeticiones = rutinaEjer.Repeticiones,
                Series = rutinaEjer.Series,
                Descanso = rutinaEjer.Descanso
            };

        }

        HistoricoRutinaEjer Convertir(HistoricoRutinaEjercicioModel rutinaEjer)
        {

            return new HistoricoRutinaEjer
            
            {
                IdHisRutEjer = rutinaEjer.IdHisRutEjer,
                IdHistRutina = rutinaEjer.IdHistRutina,
                IdEjercicio = rutinaEjer.IdEjercicio,
                Repeticiones = rutinaEjer.Repeticiones,
                Series = rutinaEjer.Series,
                Descanso = rutinaEjer.Descanso
            };

        }

        public HistoricoRutinaEjercicioController()
        {
            rutinaEjerDAL = new HistoricoRutinaEjerDALImpl();

        }

        // GET: api/<HistoricoRutinaEjercicioController>
        [HttpGet]
        public JsonResult Get()
        {
            List<HistoricoRutinaEjer> rutinaEjercicios = rutinaEjerDAL.GetAll().ToList();
            List<HistoricoRutinaEjercicioModel> result = new List<HistoricoRutinaEjercicioModel>();
            foreach (HistoricoRutinaEjer rutinaEjer in rutinaEjercicios)
            {
                result.Add(Convertir(rutinaEjer));
            }
            return new JsonResult(result);
        }

        // GET api/<HistoricoRutinaEjercicioController>/{id}
        [HttpGet("{id}")]
        public JsonResult GetOne(int id)
        {
            HistoricoRutinaEjer rutinaEjer = rutinaEjerDAL.Get(id);

            return new JsonResult(Convertir(rutinaEjer));
        }

        // POST api/<HistoricoRutinaEjercicioController>
        [HttpPost]
        public JsonResult Post([FromBody] HistoricoRutinaEjercicioModel rutinaEjer)
        {
            rutinaEjerDAL.Add(Convertir(rutinaEjer));

            return new JsonResult(Convertir(rutinaEjer));
        }

        // PUT api/<HistoricoRutinaEjercicioController>/{id}
        [HttpPut]
        public JsonResult Put([FromBody] HistoricoRutinaEjer rutinaEjer)
        {
            rutinaEjerDAL.Update(rutinaEjer);

            return new JsonResult(Convertir(rutinaEjer));
        }
        // DELETE api/<HistoricoRutinaEjercicioController>/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            HistoricoRutinaEjer rutinaEjer = new HistoricoRutinaEjer()
            {
                IdHisRutEjer = id
            };
            rutinaEjerDAL.Remove(rutinaEjer);
        }
    }
}