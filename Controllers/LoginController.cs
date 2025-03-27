using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Projeto_Event_.Domains;
using Projeto_Event_.DTO;
using Projeto_Event_.Interfaces;


namespace Projeto_Event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarios _usuarioRepository;
        public LoginController(IUsuarios usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Endpoint para realizar a autenticação (Login)
        /// </summary>
        /// <param name="loginDTO">Email e senha do usuário</param>
        /// <returns>Token de acesso</returns>
        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                Usuarios usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(loginDTO.Email!, loginDTO.Senha!);

                if (usuarioBuscado == null)
                {
                    return NotFound("Usuário não encontrado, emaill ou senha inválidos!");
                }

                //Caso o usuário seja encontrado, prossegue para a criação do token

                //1º Passo - Definir as Claims() que serão fornecidos no token(Payload)
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuarios.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email!),
                    new Claim ("Tipo do usuario", usuarioBuscado.IdTipoUsuarios.ToString()!),
                    

                    //podemos definir uma claim personalizada
                    new Claim(" Claim Personalizada ","Valor da Claim Personalizada")
                };

                //2º Passo - Definir a chave de acesso do token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("eventos-chave-autenticacao-Projeto Event+"));

                //3º Passo - Definir as credenciais do Token (HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º Passo - Gerar o Token
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "Projeto Event+",

                    //destinatário do token
                    audience: "Projeto Event+",

                    //dados definidos nas claims
                    claims: claims,

                    //tempo de expiração do token
                    expires: DateTime.Now.AddMinutes(5),

                    //credenciais do token
                    signingCredentials: creds
                );

                //retorna o token criado
                return Ok(
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                    );

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
