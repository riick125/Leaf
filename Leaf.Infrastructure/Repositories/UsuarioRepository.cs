using Leaf.Domain.Entidades;
using Leaf.Domain.Interfaces;
using Leaf.Infrastructure.Context;
using Leaf.Infrastructure.Repositories.Base;

namespace Leaf.Infrastructure.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(LeafDbContext context) : base(context)
        {
        }

        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            try
            {
                var result = await GetAllAsync();

                return result.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}