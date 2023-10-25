using ApiAlkemyPI.Models;

namespace ApiAlkemyPI.Repository
{
    public interface IServiciosRepository
    {
        IEnumerable<ServiciosModel> GetAllServicios();
        ServiciosModel GetServicioById(int id);
        void AddServicio(ServiciosModel servicio);
        void UpdateServicio(ServiciosModel servicio);
        void DeleteServicio(int id);
    }
}
