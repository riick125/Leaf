using Leaf.Domain.Entidades;
using Leaf.Domain.Interfaces.Base;

namespace Leaf.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<List<Usuario>> BuscarTodosUsuarios();
    }
}