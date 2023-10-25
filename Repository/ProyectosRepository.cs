using ApiAlkemyPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAlkemyPI.Repository
{
    public class ProyectosRepository : IProyectosRepository
    {
        private readonly AlkemyDbContext _dbContext;
        public ProyectosRepository(AlkemyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProyecto(ProyectosModel proyecto)
        {
            throw new NotImplementedException();
        }

        public void DeleteProyecto(int id)
        {
            throw new NotImplementedException();
        }
        public ProyectosModel GetProyectoById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProyecto(ProyectosModel proyecto)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ProyectosModel> IProyectosRepository.GetAllProyectos()
        {
            return _dbContext.ProyectosModels.ToList();
        }
    }
}
