using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Event_.Domains;
using Projeto_Event_.Interfaces;

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

        [HttpPut]


        public IActionResult Put(Guid Id, Presencas presencas)
        {
            try
            {
                _presencasRepository.Atualizar(Id, presencas);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                _presencasRepository.Deletar(Id);
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
