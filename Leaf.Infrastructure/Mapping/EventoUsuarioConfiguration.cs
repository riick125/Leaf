using Leaf.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leaf.Infrastructure.Mapping
{
    public class EventoUsuarioConfiguration : IEntityTypeConfiguration<EventoUsuario>
    {
        public void Configure(EntityTypeBuilder<EventoUsuario> builder)
        {
            builder.ToTable("EventoUsuario");

            builder.HasKey(eu => new { eu.EventoId, eu.UsuarioId });

            builder.HasOne(eu => eu.Evento)
                .WithMany(e => e.EventoUsuarios)
                .HasForeignKey(eu => eu.EventoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(eu => eu.Usuario)
                .WithMany(u => u.EventoUsuarios)
                .HasForeignKey(eu => eu.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
