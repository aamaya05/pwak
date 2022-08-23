using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteDAL clienteDAL;

        ClienteModel Convertir(Cliente cliente)
        {

            return new ClienteModel
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Apellido1 = cliente.Apellido1,
                Apellido2 = cliente.Apellido2,
                Cedula = cliente.Cedula,
                Telefono = cliente.Telefono,
                IdRol = cliente.IdRol

            };

        }

        Cliente Convertir(ClienteModel cliente)
        {

            return new Cliente
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Apellido1 = cliente.Apellido1,
                Apellido2 = cliente.Apellido2,
                Cedula = cliente.Cedula,
                Telefono = cliente.Telefono,
                IdRol = cliente.IdRol
            };

        }

        public ClienteController()
        {
            clienteDAL = new ClienteDALImpl();

        }

        // GET: api/<ClienteController>
        [HttpGet]
        public JsonResult Get()
        {
            List<Cliente> clientes = clienteDAL.GetAll().ToList();
            List<ClienteModel> result = new List<ClienteModel>();
            foreach (Cliente cliente in clientes)
            {
                result.Add(Convertir(cliente));
            }
            return new JsonResult(result);
        }

        [Authorize]
        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Cliente cliente = clienteDAL.Get(id);

            return new JsonResult(Convertir(cliente));
        }

        // POST api/<ClienteController>
        [HttpPost]
        public JsonResult Post([FromBody] ClienteModel cliente)
        {
            clienteDAL.Add(Convertir(cliente));

            return new JsonResult(Convertir(cliente));
        }

        // PUT api/<ClienteController>/5
        [HttpPut]
        public JsonResult Put([FromBody] Cliente cliente)
        {
            clienteDAL.Update(cliente);

            return new JsonResult(Convertir(cliente));
        }
        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Cliente cliente = new Cliente
            {
                IdCliente = id
            };
            clienteDAL.Remove(cliente);
        }
    }
}
