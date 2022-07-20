using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class BitacoraDALImpl : IBitacoraDAL
    {

        PWAKContext context;
        public BitacoraDALImpl()
        {
            context = new PWAKContext();
        }


        public bool Add(Bitacora entity)
        {
            try
            {

                using (UnidadDeTrabajo<Bitacora> unidad = new UnidadDeTrabajo<Bitacora>(context))
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

        public void AddRange(IEnumerable<Bitacora> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bitacora> Find(Expression<Func<Bitacora, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Bitacora Get(int Bitacoraid)
        {
            try
            {
                Bitacora bitacora;
                using (UnidadDeTrabajo<Bitacora> unidad = new UnidadDeTrabajo<Bitacora>(context))
                {
                    bitacora = unidad.genericDAL.Get(Bitacoraid);
                }
                return bitacora;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Bitacora> Get()
        {
            try
            {
                IEnumerable<Bitacora> bitacoras;
                using (UnidadDeTrabajo<Bitacora> unidad = new UnidadDeTrabajo<Bitacora>(context))
                {
                    bitacoras = unidad.genericDAL.GetAll();
                }
                return bitacoras.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IEnumerable<Bitacora> GetAll()
        {
            try
            {
                IEnumerable<Bitacora> bitacoras;
                using (UnidadDeTrabajo<Bitacora> unidad = new UnidadDeTrabajo<Bitacora>(context))
                {
                    bitacoras = unidad.genericDAL.GetAll();
                }
                return bitacoras;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool Remove(Bitacora entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Bitacora> unidad = new UnidadDeTrabajo<Bitacora>(context))
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


        public void RemoveRange(IEnumerable<Bitacora> entities)
        {
            throw new NotImplementedException();
        }

        public Bitacora SingleOrDefault(Expression<Func<Bitacora, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Bitacora bitacora)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Bitacora> unidad = new UnidadDeTrabajo<Bitacora>(context))
                {
                    unidad.genericDAL.Update(bitacora);
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
