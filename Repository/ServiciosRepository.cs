using ApiAlkemyPI.Models;

namespace ApiAlkemyPI.Repository
{
    public class ServiciosRepository : IServiciosRepository
    {
        private readonly AlkemyDbContext _dbContext;
        public ServiciosRepository(AlkemyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddServicio(ServiciosModel servicio)
        {
            throw new NotImplementedException();
        }

        public void DeleteServicio(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiciosModel> GetAllServicios()
        {
            throw new NotImplementedException();
        }

        public ServiciosModel GetServicioById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateServicio(ServiciosModel servicio)
        {
            throw new NotImplementedException();
        }
    }
}
