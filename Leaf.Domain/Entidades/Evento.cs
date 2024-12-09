using Leaf.Domain.Entidades.Base;
using Leaf.Domain.Enumeradores;

namespace Leaf.Domain.Entidades
{
    public class Evento : Entidade
    {
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public DateTime DataLocal { get; set; }

        public short Tipo { get; set; }

        public bool Ativo { get; set; }

        public ICollection<EventoUsuario> EventoUsuarios { get; set; }
    }
}