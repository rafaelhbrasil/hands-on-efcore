using Microsoft.EntityFrameworkCore;
using WebAppEF.Repositorio.Mappings;

namespace WebAppEF.Repositorio
{
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
        }
    }
}
