using Leaf.Domain.Entidades;
using Leaf.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Leaf.Infrastructure.Context
{
    public class LeafDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<EventoUsuario> EventoUsuarios { get; set; }

        public LeafDbContext(DbContextOptions<LeafDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new EventoConfiguration());
            modelBuilder.ApplyConfiguration(new EventoUsuarioConfiguration());
        }
    }
}