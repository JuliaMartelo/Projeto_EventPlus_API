using System.Linq;
using api_filmes_senai.Utils;
using Projeto_Event_.Context;
using Projeto_Event_.Domains;
using Projeto_Event_.Interfaces;
using static Projeto_Event_.Repository.UsuariosRepository;

namespace Projeto_Event_.Repository
{
    public class UsuariosRepository : IUsuarios
    {
        private readonly Event_Context _context;

        public UsuariosRepository(Event_Context context)
        {
            _context = context;
        }

        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            try
            {
                Usuarios usuarioBuscado = _context.Usuarios.Select(u => new Usuarios
                {
                    
                    IdUsuarios = u.IdUsuarios,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,

                    TipoUsuario = new TiposUsuarios
                    {
                        IdTipoUsuario = u.IdTipoUsuarios,
                        TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                    }
                }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuarios BuscarPorId(Guid Id)
        {
            try
            {
                Usuarios usuarioBuscado = _context.Usuarios
                    .Select(u => new Usuarios
                    {
                        IdUsuarios = u.IdUsuarios,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TiposUsuarios
                        {
                            IdTipoUsuario = u.TipoUsuario!.IdTipoUsuario,
                            TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                        }

                    }).FirstOrDefault(u => u.IdUsuarios == Id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;

                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuarios usuarios)
        {
            try
            {
                usuarios.IdUsuarios = Guid.NewGuid();

                usuarios.Senha = Criptografia.GerarHash(usuarios.Senha!);

                _context.Usuarios.Add(usuarios);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        
        }
    }
}
