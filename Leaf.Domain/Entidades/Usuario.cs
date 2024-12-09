using Leaf.Domain.Entidades.Base;

namespace Leaf.Domain.Entidades
{
    public class Usuario : Entidade
    {
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public ICollection<EventoUsuario> EventoUsuarios { get; set; }

        public ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    }
}