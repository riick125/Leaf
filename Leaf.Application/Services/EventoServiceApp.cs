using AutoMapper;
using Leaf.Application.Dtos;
using Leaf.Application.Interfaces;
using Leaf.Application.Results.Base;
using Leaf.Domain.Entidades;
using Leaf.Domain.Enumeradores;
using Leaf.Domain.Interfaces;

namespace Leaf.Application.Services
{
    public class EventoServiceApp : IEventoServiceApp
    {
        private readonly IMapper _mapper;

        private readonly IEventoRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;

        public EventoServiceApp(IMapper mapper,
            IEventoRepository repository,
            IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;

            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ResultDto> BuscarTodosUsuarios()
        {
            try
            {
                var usuarios = await _usuarioRepository.BuscarTodosUsuarios();

                return new ResultDto(string.Empty, usuarios);
            }
            catch (Exception ex)
            {   
                return new ResultDto("Erro ao realizar operação!");
            }
        }

        public async Task<ResultDto> IncluirEvento(EventoDto dto)
        {
            try
            {
                var validarEvento = await ValidarEvento(dto);

                if (!validarEvento.Sucesso)
                {
                    return validarEvento;
                }

                var evento = _mapper.Map<EventoDto, Evento>(dto);

                var result = await _repository.IncluirEvento(evento, dto.UsuariosId);

                return new ResultDto(string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ResultDto("Erro ao realizar operação!");
            }
        }

        private async Task<ResultDto> ValidarEvento(EventoDto dto)
        {
            if (dto.Tipo == (int)TipoEventoEnum.Compartilhado)
            {
                var msgErro = "Por favor, selecione um participante...";

                if (dto.UsuariosId == null)
                {
                    return new ResultDto(msgErro);
                }
                else if (!dto.UsuariosId.Any())
                {
                    return new ResultDto(msgErro);
                }
            }

            if (dto.Tipo == (int)TipoEventoEnum.Exclusivo && dto.DataLocal.HasValue && await _repository.ExisteEventoMesmaData(dto.DataLocal.Value))
            {
                return new ResultDto($"Já existe um evento para esta data: {dto.DataLocal}");
            }

            return new ResultDto("");
        }

        public async Task<ResultDto> ListarEventos()
        {
            try
            {
                var usuarios = await _repository.ListarEventos();

                return new ResultDto(string.Empty, usuarios);
            }
            catch (Exception ex)
            {
                return new ResultDto("Erro ao realizar operação!");
            }
        }
    }
}