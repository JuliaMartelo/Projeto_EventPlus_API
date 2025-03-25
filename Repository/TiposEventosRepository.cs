using Projeto_Event_.Context;
using Projeto_Event_.Domains;
using Projeto_Event_.Interfaces;

namespace Projeto_Event_.Repository
{
    public class TiposEventosRepository : ITiposEventos
    {
        private readonly Event_Context? _context;

        public TiposEventosRepository(Event_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid Id, TiposEventos tiposEventos)
        {
            try
            {
                TiposEventos tipoBuscado = _context.TiposEventos.Find(Id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.TituloTipoEvento = tiposEventos.TituloTipoEvento;
                }

                _context.TiposEventos.Update(tipoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TiposEventos BuscarPorId(Guid Id)
        {
            try
            {
                return _context?.TiposEventos.Find(Id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TiposEventos tiposEventos)
        {
            try
            {
                tiposEventos.IdTipoEvento = Guid.NewGuid();

                _context.TiposEventos.Add(tiposEventos);

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
                TiposEventos tipoBuscado = _context?.TiposEventos.Find(Id)!;

                if (tipoBuscado != null)
                {
                    _context?.TiposEventos.Remove(tipoBuscado);
                }

                _context?.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public List<TiposEventos> Listar()
        {
            try
            {
                return _context.TiposEventos
                    .OrderBy(tp => tp.TituloTipoEvento)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
