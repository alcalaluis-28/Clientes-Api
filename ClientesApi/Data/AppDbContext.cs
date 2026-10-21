using ClientesApi.Models;
using Microsoft.EntityFrameworkCore; //Acceder BD

namespace ClientesApi.Data
{
    //Herencia => subClase : superclase
    public class AppDbContext : DbContext
    {
        //Constructor (inicializar)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //ORM tendrá acceso al modelo cliente
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}