using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Event_.Domains;
using Projeto_Event_.Interfaces;
using Projeto_Event_.Repository;

namespace Projeto_Event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IEventos _EventosRepository;

        public EventosController(IEventos EventosRepository)
        {
            _EventosRepository = EventosRepository;
        }

        [HttpPost]
        public IActionResult Post(Eventos eventos)
        {
            try
            {
                _EventosRepository.Cadastrar(eventos);
                return Created();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public IActionResult Put(Guid Id, Eventos eventos)
        {
            try
            {
                _EventosRepository.Atualizar(Id, eventos);
                return NoContent();

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(Guid Id)
        {
            try
            {
                Eventos EventosBuscado = _EventosRepository.BuscarPorId(Id);
                return Ok(EventosBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _EventosRepository.Deletar(Id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Eventos> ListaEventos = _EventosRepository.Listar();
                return Ok(ListaEventos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{ListarId}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                List<Eventos> ListaEventoPorID = _EventosRepository.listarId(Id);
                return Ok(ListaEventoPorID);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{ListarProximoEvento}")]
        public IActionResult ListarProximoEvento()
        {
            try
            {
                List<Eventos> ListaProximoEvento = _EventosRepository.listarProximoEvento();
                return Ok(ListaProximoEvento);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
