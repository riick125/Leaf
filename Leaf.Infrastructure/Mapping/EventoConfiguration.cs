using Leaf.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leaf.Infrastructure.Mapping
{
    public class EventoConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Evento");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Descricao)
                .HasMaxLength(255);

            builder.Property(e => e.DataLocal)
                .IsRequired();

            builder.Property(e => e.Tipo)
                .IsRequired();

            builder.HasOne(e => e.Usuario)
                .WithMany(u => u.Eventos)
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}