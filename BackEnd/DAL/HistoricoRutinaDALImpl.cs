using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class HistoricoRutinaDALImpl : IHistoricoRutinaDAL
    {
        PWAKContext context;
        public HistoricoRutinaDALImpl()
        {
            context = new PWAKContext();
        }

        public bool Add(HistoricoRutina entity)
        {
            try
            {

                using (UnidadDeTrabajo<HistoricoRutina> unidad = new UnidadDeTrabajo<HistoricoRutina>(context))
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

        public void AddRange(IEnumerable<HistoricoRutina> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HistoricoRutina> Find(Expression<Func<HistoricoRutina, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public HistoricoRutina Get(int HistoricoRutinaid)
        {
            try
            {
                HistoricoRutina historicorutina;
                using (UnidadDeTrabajo<HistoricoRutina> unidad = new UnidadDeTrabajo<HistoricoRutina>(context))
                {
                    historicorutina = unidad.genericDAL.Get(HistoricoRutinaid);
                }
                return historicorutina;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<HistoricoRutina> Get()
        {
            try
            {
                IEnumerable<HistoricoRutina> historicorutinas;
                using (UnidadDeTrabajo<HistoricoRutina> unidad = new UnidadDeTrabajo<HistoricoRutina>(context))
                {
                    historicorutinas = unidad.genericDAL.GetAll();
                }
                return historicorutinas.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<HistoricoRutina> GetAll()
        {
            try
            {
                IEnumerable<HistoricoRutina> historicorutinas;
                using (UnidadDeTrabajo<HistoricoRutina> unidad = new UnidadDeTrabajo<HistoricoRutina>(context))
                {
                    historicorutinas = unidad.genericDAL.GetAll();
                }
                return historicorutinas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(HistoricoRutina entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<HistoricoRutina> unidad = new UnidadDeTrabajo<HistoricoRutina>(context))
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

        public void RemoveRange(IEnumerable<HistoricoRutina> entities)
        {
            throw new NotImplementedException();
        }

        public HistoricoRutina SingleOrDefault(Expression<Func<HistoricoRutina, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(HistoricoRutina historicorutina)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<HistoricoRutina> unidad = new UnidadDeTrabajo<HistoricoRutina>(context))
                {
                    unidad.genericDAL.Update(historicorutina);
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

