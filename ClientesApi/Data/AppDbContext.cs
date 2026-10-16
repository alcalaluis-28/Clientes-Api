using ClienteApi.Models; //Modelo (definición tabla)
using Microsoft.EntityFrameworkCore; //Acceder BD

namespace ClientesApi.Data
{
    //Herencia => subClase : superClass
    public class AppDbContext : DbContext
    {
        //Constructor (inicializar)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //ORM tendrá acceso al modelo cliente
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}