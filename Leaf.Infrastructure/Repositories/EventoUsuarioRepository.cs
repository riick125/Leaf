using Leaf.Domain.Entidades;
using Leaf.Domain.Interfaces;
using Leaf.Infrastructure.Context;
using Leaf.Infrastructure.Repositories.Base;

namespace Leaf.Infrastructure.Repositories
{
    public class EventoUsuarioRepository : Repository<EventoUsuario>, IEventoUsuarioRepository
    {
        public EventoUsuarioRepository(LeafDbContext context) : base(context)
        {
        }
    }
}