using Microsoft.EntityFrameworkCore;
using Proyecto.Shared.Entidad;

namespace Proyecto.API.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        { 
        
        }

        public DbSet<Usuario> Usuarios { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Carnet).IsUnique();

        }

    }
}
