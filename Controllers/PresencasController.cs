using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Event_.Domains;
using Projeto_Event_.Interfaces;
using Projeto_Event_.Repository;

namespace Projeto_Event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresencasController : ControllerBase
    {
        private readonly IPresencas _presencasRepository;

        public PresencasController(IPresencas presencasRepository)
        {
            _presencasRepository = presencasRepository;
        }


        /// <summary>
        /// Endpoint para cadastrar novo evento
        /// </summary>
        [HttpPost]
        public IActionResult Post(Presencas presencaRepository)
        {
            try
            {
                _presencasRepository.Inscricao(presencaRepository);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

       


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Presencas> ListaPresencas = _presencasRepository.Listar();
                return Ok(ListaPresencas);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("ListarMinhas/{Id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                List<Presencas> ListaMinhas = _presencasRepository.ListarMinhas(Id);
                return Ok(ListaMinhas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Put(Guid id, Presencas presencas)
        {
            try
            {
                _presencasRepository.Atualizar(id, presencas);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid Id)
        {
            try
            {
                Presencas presencaBuscada = _presencasRepository.BuscarPorId(Id);

                return Ok(presencaBuscada);
            }
            
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
