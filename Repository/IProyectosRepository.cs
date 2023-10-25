using ApiAlkemyPI.Models;

namespace ApiAlkemyPI.Repository
{
    public interface IProyectosRepository
    {
        IEnumerable<ProyectosModel> GetAllProyectos();
        ProyectosModel GetProyectoById(int id);
        void AddProyecto(ProyectosModel proyecto);
        void UpdateProyecto(ProyectosModel proyecto);
        void DeleteProyecto(int id);
    }
}
