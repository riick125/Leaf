using Leaf.Application.Dtos.Base;

namespace Leaf.Application.Dtos
{
    public class UsuarioDto : EntityDto
    {
        public string? Nome { get; set; }

        public string? Email { get; set; }
    }
}