﻿using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class UsuarioDALImpl : IUsuarioDAL
    {
        PWAKContext context;
        public UsuarioDALImpl()
        {
            context = new PWAKContext();
        }

        public bool Add(Usuario entity)
        {
            try
            {

                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
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

        public void AddRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> Find(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Usuario Get(int Usuarioid)
        {
            try
            {
                Usuario usuario;
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
                {
                    usuario = unidad.genericDAL.Get(Usuarioid);
                }
                return usuario;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Usuario> Get()
        {
            try
            {
                IEnumerable<Usuario> usuarios;
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
                {
                    usuarios = unidad.genericDAL.GetAll();
                }
                return usuarios.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            try
            {
                IEnumerable<Usuario> usuarios;
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
                {
                    usuarios = unidad.genericDAL.GetAll();
                }
                return usuarios;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Usuario entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
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

        public void RemoveRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        public Usuario SingleOrDefault(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario usuario)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(context))
                {
                    unidad.genericDAL.Update(usuario);
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
