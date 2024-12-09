using Leaf.Domain.Entidades;
using Leaf.Domain.Interfaces.Base;

namespace Leaf.Domain.Interfaces
{
    public interface IEventoRepository : IRepository<Evento>
    {
        Task<List<Evento>> ListarEventos();
        Task<bool> IncluirEvento(Evento evento, List<int> idsParticipantes = null);
        Task<bool> ExisteEventoMesmaData(DateTime data);
    }
}