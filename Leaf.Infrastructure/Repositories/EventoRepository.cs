using Leaf.Domain.Entidades;
using Leaf.Domain.Enumeradores;
using Leaf.Domain.Interfaces;
using Leaf.Infrastructure.Context;
using Leaf.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Leaf.Infrastructure.Repositories
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        private readonly IEventoUsuarioRepository _eventoUsuarioRepository;

        public EventoRepository(LeafDbContext context, IEventoUsuarioRepository eventoUsuarioRepository) : base(context)
        {
            _eventoUsuarioRepository = eventoUsuarioRepository;
        }

        public async Task<bool> IncluirEvento(Evento evento, List<int> idsParticipantes = null)
        {
            try
            {
                await AddAsync(evento);

                if (evento.Tipo == (short)TipoEventoEnum.Compartilhado && idsParticipantes != null)
                {
                    foreach (var id in idsParticipantes)
                    {
                        var eventoUsuario = new EventoUsuario() { EventoId = evento.Id, UsuarioId = id };

                        await _eventoUsuarioRepository.AddAsync(eventoUsuario);                        
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ExisteEventoMesmaData(DateTime data)
        {
            try
            {
                return await _dbSet.AnyAsync(x => x.Tipo == (short)TipoEventoEnum.Exclusivo && x.DataLocal == data);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Evento>> ListarEventos()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}