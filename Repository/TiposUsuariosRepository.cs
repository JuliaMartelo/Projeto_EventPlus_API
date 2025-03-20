using Projeto_Event_.Context;
using Projeto_Event_.Domains;
using Projeto_Event_.Interfaces;

namespace Projeto_Event_.Repository
{
    public class TiposUsuariosRepository : ITiposUsuarios
    {
        private readonly Event_Context _context;

        public TiposUsuariosRepository(Event_Context context)
        {
            _context = context;
        }
        public void Atualizar(Guid Id, TiposUsuarios tiposusuarios)
        {
            try
            {
                TiposUsuarios tiposUsuariosBuscado = _context.TiposUsuarios.Find(Id)!;

                if(tiposUsuariosBuscado != null)
                {
                    tiposUsuariosBuscado.TituloTipoUsuario = tiposusuarios.TituloTipoUsuario;
                    tiposUsuariosBuscado.IdTipoUsuario = tiposusuarios.IdTipoUsuario;
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TiposUsuarios BuscarPorId(Guid Id)
        {
            try
            {
                TiposUsuarios tiposUsuariosBuscado = _context.TiposUsuarios.Find(Id)!;

                return tiposUsuariosBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TiposUsuarios tiposUsuarios)
        {
            try
            {
                _context.TiposUsuarios.Add(tiposUsuarios);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid Id)
        {
            try
            {
                TiposUsuarios tiposUsuariosBuscado = _context.TiposUsuarios.Find(Id)!;

                if(tiposUsuariosBuscado != null)
                {
                    _context.TiposUsuarios.Remove(tiposUsuariosBuscado); 
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TiposUsuarios> Listar()
        {
            try
            {
                List<TiposUsuarios> listaTiposUsuarios = _context!.TiposUsuarios.ToList();

                return listaTiposUsuarios;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
