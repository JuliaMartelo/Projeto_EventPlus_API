using Microsoft.AspNetCore.Mvc;
using Projeto_Event_.Domains;
using Projeto_Event_.Interfaces;
using Projeto_Event_.Repository;

namespace Projeto_Event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosEventosController : ControllerBase
    {
        private readonly IComentariosEventos _ComentariosEventosRepository;

        public ComentariosEventosController(IComentariosEventos comentarioEventoRepository)
        {
            _ComentariosEventosRepository = comentarioEventoRepository;
        }

        [HttpPost]
        public IActionResult Post(ComentariosEventos novoComentario)
        {
            try
            {
                _ComentariosEventosRepository.Cadastrar(novoComentario);
                return Created();
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
                _ComentariosEventosRepository.Delete(Id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(Guid Id)
        {
            try
            {
                List<ComentariosEventos> ListarComentariosEventos = _ComentariosEventosRepository.Listar(Id);

                return Ok(ListarComentariosEventos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
