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
                TiposEventos tipoeventoBuscado = _context?.TiposEventos.Find(Id)!;

                if (tipoeventoBuscado != null)
                {
                    tipoeventoBuscado.IdTipoEvento = tiposEventos.IdTipoEvento;

                    
                }
                _context?.SaveChanges();
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
                TiposEventos tipoeventoBuscado = _context?.TiposEventos.Find(Id)!;
                if(tipoeventoBuscado != null)
                {
                    return tipoeventoBuscado;
                }
                    return null!;
                
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
                _context?.TiposEventos.Add(tiposEventos);

                _context?.SaveChanges();
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
                TiposEventos tiposEventosBuscado = _context?.TiposEventos.Find(Id)!;
                if (tiposEventosBuscado != null)
                {
                    _context?.TiposEventos.Remove(tiposEventosBuscado);
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
                List<TiposEventos> listaTiposEventos = _context!.TiposEventos.ToList();

                return listaTiposEventos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
