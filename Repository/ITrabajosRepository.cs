using ApiAlkemyPI.Models;

namespace ApiAlkemyPI.Repository
{
    public interface ITrabajosRepository
    {
        IEnumerable<TrabajosModel> GetAllTrabajos();
        TrabajosModel GetTrabajoById(int id);
        void AddTrabajo(TrabajosModel trabajo);
        void UpdateTrabajo(TrabajosModel trabajo);
        void DeleteTrabajo(int id);
    }
}
