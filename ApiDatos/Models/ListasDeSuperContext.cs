using Microsoft.EntityFrameworkCore;

namespace ApiDatos.Models
{
    public class ListasDeSuperContext : DbContext
    {
        public ListasDeSuperContext(DbContextOptions<ListasDeSuperContext> options): base(options)
        { }

        public DbSet<Listas> Listas { get; set; }
    }
}
