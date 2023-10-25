using ApiAlkemyPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAlkemyPI
{
    public class AlkemyDbContext : DbContext
    {
        
        public AlkemyDbContext(DbContextOptions<AlkemyDbContext> options)
            : base(options)
        {

        }
        public DbSet<ProyectosModel> ProyectosModels { get; set; }
        public DbSet<ServiciosModel> ServiciosModels { get; set; }
        public DbSet<TrabajosModel> TrabajosModels { get; set; }
        public DbSet<UsuariosModel> UsuariosModels { get; set; }
    }
}
