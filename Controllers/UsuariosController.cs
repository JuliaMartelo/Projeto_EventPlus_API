using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Event_.Domains;
using Projeto_Event_.Interfaces;

namespace Projeto_Event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarios _UsuarioRepository;

        public UsuariosController(IUsuarios usuarioRepository)
        {
            _UsuarioRepository = usuarioRepository;
        }

        [HttpGet("BuscarPorEmailESenha")]
        public IActionResult Get(string email, string senha)
        {
            try
            {

                Usuarios usuarioBuscado = _UsuarioRepository.BuscarPorEmailSenha(email, senha);

                if (usuarioBuscado != null)
                {
                    return Ok(usuarioBuscado);
                }
                return null!;
            }

            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorId{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Usuarios usuarioBuscado = _UsuarioRepository.BuscarPorId(id);
                return Ok(usuarioBuscado);
                if (usuarioBuscado != null)
                {
                    return Ok(usuarioBuscado);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Post(Usuarios novoUsuario)
        {
            try
            {
                _UsuarioRepository.Cadastrar(novoUsuario);
                return Created();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

