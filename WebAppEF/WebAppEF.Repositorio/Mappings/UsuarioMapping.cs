using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAppEF.Repositorio.Mappings
{
    internal class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(nameof(Usuario))
                .HasKey(p => p.Id); // Chave primária da tabela
            builder.Property(p => p.Nome)
                .HasMaxLength(180); // texto de tamanho 180
            builder.Property(p => p.Email)
                .HasMaxLength(255); // texto de tamanho 255
        }
    }
}
