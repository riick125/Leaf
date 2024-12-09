using AutoMapper;
using Leaf.Application.Dtos;
using Leaf.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Leaf.Controllers
{
    public class EventoController : Controller
    {
        private readonly IMapper _mapper;

        private readonly ILogger<HomeController> _logger;

        private readonly IEventoServiceApp _serviceApp;

        public EventoController(IMapper mapper,
            ILogger<HomeController> logger,
            IEventoServiceApp serviceApp)
        {
            _mapper = mapper;

            _logger = logger;

            _serviceApp = serviceApp;
        }

        public IActionResult Incluir()
        {
            return View("Incluir");
        }

        public IActionResult Listar()
        {
            return View("Listar");
        }

        [HttpPost]
        public async Task<IActionResult> IncluirEvento([FromBody] EventoDto dto)
        {
            try
            {
                var result = await _serviceApp.IncluirEvento(dto);

                if (result.Sucesso)
                {
                    return Ok(result.Data);
                }

                return BadRequest(result.MensagemErro);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao realizar operação");
            }
        }


        [HttpGet]
        public async Task<IActionResult> BuscarTodosUsuarios()
        {
            try
            {
                var result = await _serviceApp.BuscarTodosUsuarios();

                if (result.Sucesso)
                {
                    return Ok(result.Data);
                }

                return BadRequest(result.MensagemErro);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao realizar operação");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarEventos()
        {
            try
            {
                var result = await _serviceApp.ListarEventos();

                if (result.Sucesso)
                {
                    return Ok(result.Data);
                }

                return BadRequest(result.MensagemErro);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao realizar operação");
            }
        }
    }
}