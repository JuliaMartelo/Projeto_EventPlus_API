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
                TiposUsuarios tipoBuscado = _context.TiposUsuarios.Find(Id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.TituloTipoUsuario = tiposusuarios.TituloTipoUsuario;
                }

                _context.TiposUsuarios.Update(tipoBuscado!);

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
                return _context.TiposUsuarios.Find(Id)!;
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
                tiposUsuarios.IdTipoUsuario = Guid.NewGuid();

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
                TiposUsuarios tipoBuscado = _context.TiposUsuarios.Find(Id)!;

                if (tipoBuscado != null)
                {
                    _context.TiposUsuarios.Remove(tipoBuscado);
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
                return _context.TiposUsuarios.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
