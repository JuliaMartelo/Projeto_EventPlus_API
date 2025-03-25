using Projeto_Event_.Context;
using Projeto_Event_.Domains;
using Projeto_Event_.Interfaces;

namespace Projeto_Event_.Repository
{
    public class EventosRepository : IEventos
    {
        private readonly Event_Context? _context;

        public EventosRepository(Event_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid Id, Eventos eventos)
        {
            try
            {
                Eventos EventosBuscado = _context?.Eventos.Find(Id)!;

                if (EventosBuscado != null)
                {
                    EventosBuscado.NomeEvento = eventos.NomeEvento;

                    EventosBuscado.TipoEventoID = eventos.TipoEventoID;

                    EventosBuscado.Descricao = eventos.Descricao;

                    EventosBuscado.DataEvento = eventos.DataEvento;
                }
                _context?.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Eventos BuscarPorId(Guid Id)
        {
            try
            {
                Eventos EventosBuscado = _context?.Eventos.Find(Id)!;
                return EventosBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Eventos novoEvento)
        {
            try
            {
                _context?.Eventos.Add(novoEvento);
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
                Eventos EventosBuscado = _context?.Eventos.Find(Id)!;
                if (EventosBuscado != null)
                {
                    _context?.Eventos.Remove(EventosBuscado);
                }
                _context?.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Eventos> Listar()
        {
            try
            {
                List<Eventos> ListaTiposEventos = _context?.Eventos.ToList()!;
                return ListaTiposEventos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Eventos> listarId(Guid Id)
        {
            try
            {
                List<Eventos> ListarPorID = _context?.Eventos.ToList()!;
                return ListarPorID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Eventos> listarProximoEvento()
        {
            try
            {
                List<Eventos> ListarProximoEvento = _context?.Eventos.ToList()!;
                return ListarProximoEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
