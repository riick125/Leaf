using Leaf.Application.Dtos;
using Leaf.Application.Results.Base;

namespace Leaf.Application.Interfaces
{
    public interface IEventoServiceApp
    {
        Task<ResultDto> BuscarTodosUsuarios();

        Task<ResultDto> ListarEventos();

        Task<ResultDto> IncluirEvento(EventoDto dto);
    }
}