using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class HistoricoRutinaEjerDALImpl : IHistoricoRutinaEjerDAL
    {

        PWAKContext context;
        public HistoricoRutinaEjerDALImpl()
        {
            context = new PWAKContext();
        }

        public bool Add(HistoricoRutinaEjer entity)
        {
            try
            {

                using (UnidadDeTrabajo<HistoricoRutinaEjer> unidad = new UnidadDeTrabajo<HistoricoRutinaEjer>(context))
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

        public void AddRange(IEnumerable<HistoricoRutinaEjer> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HistoricoRutinaEjer> Find(Expression<Func<HistoricoRutinaEjer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public HistoricoRutinaEjer Get(int HistoricoRutinaEjerid)
        {
            try
            {
                HistoricoRutinaEjer historicore;
                using (UnidadDeTrabajo<HistoricoRutinaEjer> unidad = new UnidadDeTrabajo<HistoricoRutinaEjer>(context))
                {
                    historicore = unidad.genericDAL.Get(HistoricoRutinaEjerid);
                }
                return historicore;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<HistoricoRutinaEjer> Get()
        {
            try
            {
                IEnumerable<HistoricoRutinaEjer> historicores;
                using (UnidadDeTrabajo<HistoricoRutinaEjer> unidad = new UnidadDeTrabajo<HistoricoRutinaEjer>(context))
                {
                    historicores = unidad.genericDAL.GetAll();
                }
                return historicores.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<HistoricoRutinaEjer> GetAll()
        {
            try
            {
                IEnumerable<HistoricoRutinaEjer> historicores;
                using (UnidadDeTrabajo<HistoricoRutinaEjer> unidad = new UnidadDeTrabajo<HistoricoRutinaEjer>(context))
                {
                    historicores = unidad.genericDAL.GetAll();
                }
                return historicores;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(HistoricoRutinaEjer entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<HistoricoRutinaEjer> unidad = new UnidadDeTrabajo<HistoricoRutinaEjer>(context))
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

        public void RemoveRange(IEnumerable<HistoricoRutinaEjer> entities)
        {
            throw new NotImplementedException();
        }

        public HistoricoRutinaEjer SingleOrDefault(Expression<Func<HistoricoRutinaEjer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(HistoricoRutinaEjer historicore)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<HistoricoRutinaEjer> unidad = new UnidadDeTrabajo<HistoricoRutinaEjer>(context))
                {
                    unidad.genericDAL.Update(historicore);
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


