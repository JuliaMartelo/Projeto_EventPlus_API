using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Event_.Domains;
using Projeto_Event_.Interfaces;

namespace Projeto_Event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class TiposUsuariosController : ControllerBase
    {
        private readonly ITiposUsuarios _tiposUsuariosRepository;

        public TiposUsuariosController(ITiposUsuarios tiposUsuariosRepository)
        {
            _tiposUsuariosRepository = tiposUsuariosRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TiposUsuarios> listaTiposUsuarios = _tiposUsuariosRepository.Listar();

                return Ok(listaTiposUsuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [Authorize]
        [HttpPost]
        public IActionResult Post(TiposUsuarios tiposUsuarios)
        {
            try
            {
                _tiposUsuariosRepository.Cadastrar(tiposUsuarios);

                return Created();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpPut("{Id}")]
        public IActionResult Put (Guid Id, TiposUsuarios tiposUsuarios)
        {
            try
            {
                _tiposUsuariosRepository.Atualizar(Id, tiposUsuarios);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPoId/{Id}")]
        public IActionResult Get(Guid Id)
        {
            try
            {
                List<TiposUsuarios> listaDeTiposUsuarios = _tiposUsuariosRepository.Listar();

                return Ok(listaDeTiposUsuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }




    }
}
        

