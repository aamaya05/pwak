using Microsoft.AspNetCore.Http;
using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioDAL usuarioDAL;

        UsuarioModel Convertir(Usuario usuario)
        {

            return new UsuarioModel
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellido1 = usuario.Apellido1,
                Apellido2 = usuario.Apellido2,
                Cedula = usuario.Cedula,
                Telefono = usuario.Telefono,
                IdRol = usuario.IdRol

            };

        }

        Usuario Convertir(UsuarioModel usuario)
        {

            return new Usuario
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellido1 = usuario.Apellido1,
                Apellido2 = usuario.Apellido2,
                Cedula = usuario.Cedula,
                Telefono = usuario.Telefono,
                IdRol = usuario.IdRol
            };

        }

        public UsuarioController()
        {
            usuarioDAL = new UsuarioDALImpl();

        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public JsonResult Get()
        {
            List<Usuario> usuarios = usuarioDAL.GetAll().ToList();
            List<UsuarioModel> result = new List<UsuarioModel>();
            foreach (Usuario usuario in usuarios)
            {
                result.Add(Convertir(usuario));
            }
            return new JsonResult(result);
        }

        // GET api/<UsuarioController>/{id}
        [HttpGet("{id}")]
        public JsonResult GetOne(int id)
        {
            Usuario usuario = usuarioDAL.Get(id);

            return new JsonResult(Convertir(usuario));
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public JsonResult Post([FromBody] UsuarioModel usuario)
        {
            usuarioDAL.Add(Convertir(usuario));

            return new JsonResult(Convertir(usuario));
        }

        // PUT api/<UsuarioController>/{id}
        [HttpPut]
        public JsonResult Put([FromBody] Usuario usuario)
        {
            usuarioDAL.Update(usuario);

            return new JsonResult(Convertir(usuario));
        }
        // DELETE api/<UsuarioController>/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Usuario usuario = new Usuario
            {
                IdUsuario = id
            };
            usuarioDAL.Remove(usuario);
        }
    }
}