using ApiAlkemyPI.Models;

namespace ApiAlkemyPI.Repository
{
    public interface IUsuariosRepository
    {
        IEnumerable<UsuariosModel> GetAllUsuarios();
        UsuariosModel GetUsuarioById(int id);
        void AddUsuario(UsuariosModel usurario);
        void UpdateUsuario(UsuariosModel usuario);
        void DeleteUsuario(int id);
    }
}

