using ApiAlkemyPI.Models;

namespace ApiAlkemyPI.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly AlkemyDbContext _dbContext;
        public UsuariosRepository(AlkemyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUsuario(UsuariosModel usurario)
        {
            throw new NotImplementedException();
        }

        public void DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuariosModel> GetAllUsuarios()
        {
            throw new NotImplementedException();
        }

        public UsuariosModel GetUsuarioById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUsuario(UsuariosModel usuario)
        {
            throw new NotImplementedException();
        }
    }
}
