using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class EjercicioDALImpl : IEjercicioDAL
    {
        PWAKContext context;
        public EjercicioDALImpl()
        {
            context = new PWAKContext();
        }

        public bool Add(Ejercicio entity)
        {
            try
            {

                using (UnidadDeTrabajo<Ejercicio> unidad = new UnidadDeTrabajo<Ejercicio>(context))
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

        public void AddRange(IEnumerable<Ejercicio> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ejercicio> Find(Expression<Func<Ejercicio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Ejercicio Get(int Ejercicioid)
        {
            try
            {
                Ejercicio ejercicio;
                using (UnidadDeTrabajo<Ejercicio> unidad = new UnidadDeTrabajo<Ejercicio>(context))
                {
                    ejercicio = unidad.genericDAL.Get(Ejercicioid);
                }
                return ejercicio;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Ejercicio> Get()
        {
            try
            {
                IEnumerable<Ejercicio> ejercicios;
                using (UnidadDeTrabajo<Ejercicio> unidad = new UnidadDeTrabajo<Ejercicio>(context))
                {
                    ejercicios = unidad.genericDAL.GetAll();
                }
                return ejercicios.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Ejercicio> GetAll()
        {
            try
            {
                IEnumerable<Ejercicio> ejercicios;
                using (UnidadDeTrabajo<Ejercicio> unidad = new UnidadDeTrabajo<Ejercicio>(context))
                {
                    ejercicios = unidad.genericDAL.GetAll();
                }
                return ejercicios;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Ejercicio entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Ejercicio> unidad = new UnidadDeTrabajo<Ejercicio>(context))
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

        public void RemoveRange(IEnumerable<Ejercicio> entities)
        {
            throw new NotImplementedException();
        }

        public Ejercicio SingleOrDefault(Expression<Func<Ejercicio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ejercicio ejercicio)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Ejercicio> unidad = new UnidadDeTrabajo<Ejercicio>(context))
                {
                    unidad.genericDAL.Update(ejercicio);
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
