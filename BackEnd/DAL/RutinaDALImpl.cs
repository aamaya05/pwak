using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class RutinaDALImpl : IRutinaDAL
    {

        PWAKContext context;
        public RutinaDALImpl()
        {
            context = new PWAKContext();
        }

        public bool Add(Rutina entity)
        {
            try
            {

                using (UnidadDeTrabajo<Rutina> unidad = new UnidadDeTrabajo<Rutina>(context))
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

        public void AddRange(IEnumerable<Rutina> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rutina> Find(Expression<Func<Rutina, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Rutina Get(int Rutinaid)
        {
            try
            {
                Rutina rutina;
                using (UnidadDeTrabajo<Rutina> unidad = new UnidadDeTrabajo<Rutina>(context))
                {
                    rutina = unidad.genericDAL.Get(Rutinaid);
                }
                return rutina;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Rutina> Get()
        {
            try
            {
                IEnumerable<Rutina> rutinas;
                using (UnidadDeTrabajo<Rutina> unidad = new UnidadDeTrabajo<Rutina>(context))
                {
                    rutinas = unidad.genericDAL.GetAll();
                }
                return rutinas.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Rutina> GetAll()
        {
            try
            {
                IEnumerable<Rutina> rutinas;
                using (UnidadDeTrabajo<Rutina> unidad = new UnidadDeTrabajo<Rutina>(context))
                {
                    rutinas = unidad.genericDAL.GetAll();
                }
                return rutinas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Rutina entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Rutina> unidad = new UnidadDeTrabajo<Rutina>(context))
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

        public void RemoveRange(IEnumerable<Rutina> entities)
        {
            throw new NotImplementedException();
        }

        public Rutina SingleOrDefault(Expression<Func<Rutina, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Rutina rutina)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Rutina> unidad = new UnidadDeTrabajo<Rutina>(context))
                {
                    unidad.genericDAL.Update(rutina);
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

