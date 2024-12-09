using Leaf.Application.Dtos.Base;

namespace Leaf.Application.Dtos
{
    public class EventoDto : EntityDto
    {
        public int UsuarioId { get; set; }
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public DateTime? DataLocal { get; set; }

        public int? Tipo { get; set; }

        public bool Ativo { get; set; }

        public List<int>? UsuariosId { get; set; }

        public EventoDto()
        {
            Ativo = true;
            UsuariosId = new List<int>();
        }
    }
}