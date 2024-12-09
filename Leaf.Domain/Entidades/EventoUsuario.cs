namespace Leaf.Domain.Entidades
{
    public class EventoUsuario
    {
        public int EventoId { get; set; }
        public Evento? Evento { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}