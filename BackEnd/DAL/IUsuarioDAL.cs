
using System.Text;


namespace BackEnd.DAL
{
    internal interface IUsuarioDAL : IDALGenerico<Usuario>;

    {
        /// <summary>
        /// Metodo para AGREGAR Y MODIFICAR usuarios 
        /// </summary>
        /// <param name="usuario"></param>
        void Agregar(Usuario usuario);
        void Modificar(Usuario usuario);

    }
}
