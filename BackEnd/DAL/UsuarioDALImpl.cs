
using BackEnd.Entities;
using System.Linq.Expressions;
using System.Text;

namespace BackEnd.DAL
{
    public class UsuarioDALImpl : IUsuarioDAL
    {
        PWAKContext context;
        public UsuarioDALImpl()
        {
            context = new PWAKContext();
        }

        bool IDALGenerico<Usuario>.Add(Usuario entity)
        {
            throw new NotImplementedException();
        }

        void IDALGenerico<Usuario>.AddRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        void IUsuarioDAL.Agregar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Usuario> IDALGenerico<Usuario>.Find(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Usuario IDALGenerico<Usuario>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Usuario> IDALGenerico<Usuario>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IUsuarioDAL.Modificar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        bool IDALGenerico<Usuario>.Remove(Usuario entity)
        {
            throw new NotImplementedException();
        }

        void IDALGenerico<Usuario>.RemoveRange(IEnumerable<Usuario> entities)
        {
            throw new NotImplementedException();
        }

        Usuario IDALGenerico<Usuario>.SingleOrDefault(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        bool IDALGenerico<Usuario>.Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}