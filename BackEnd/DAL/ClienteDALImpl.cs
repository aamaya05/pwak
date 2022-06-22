using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class ClienteDALImpl : IClienteDAL

    {

        PWAKContext context;
        public ClienteDALImpl()
        {
            context = new PWAKContext();
        }

        public bool Add(Cliente entity)
        {
            try
            {
                
                using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<Cliente> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> Find(Expression<Func<Cliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Cliente Get(int Clienteid)
        {
            try
            {
                Cliente cliente;
                using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(context))
                {
                    cliente = unidad.genericDAL.Get(Clienteid);
                }
                return cliente;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Cliente> Get()
        {
            try
            {
                IEnumerable<Cliente> clientes;
                using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(context))
                {
                    clientes = unidad.genericDAL.GetAll();
                }
                return clientes.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            try
            {
                IEnumerable<Cliente> clientes;
                using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(context))
                {
                    clientes = unidad.genericDAL.GetAll();
                }
                return clientes; 
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Cliente entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }

        public void RemoveRange(IEnumerable<Cliente> entities)
        {
            throw new NotImplementedException();
        }

        public Cliente SingleOrDefault(Expression<Func<Cliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cliente cliente)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Cliente> unidad = new UnidadDeTrabajo<Cliente>(context))
                {
                    unidad.genericDAL.Update(cliente);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }

            return result;
        }
    }
}
