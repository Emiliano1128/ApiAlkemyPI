using ApiAlkemyPI.Models;

namespace ApiAlkemyPI.Repository
{
    public class TrabajosRepository : ITrabajosRepository
    {
        private readonly AlkemyDbContext _dbContext;
        public TrabajosRepository(AlkemyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddTrabajo(TrabajosModel trabajo)
        {
            throw new NotImplementedException();
        }

        public void DeleteTrabajo(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TrabajosModel> GetAllTrabajos()
        {
            throw new NotImplementedException();
        }

        public TrabajosModel GetTrabajoById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTrabajo(TrabajosModel trabajo)
        {
            throw new NotImplementedException();
        }
    }
}
