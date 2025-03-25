using Microsoft.Extensions.Logging;
using Projeto_Event_.Context;
using Projeto_Event_.Domains;
using Projeto_Event_.Interfaces;

namespace Projeto_Event_.Repository
{
    public class ComentariosEventosRepository : IComentariosEventos
    {
        private readonly Event_Context _context;

        public ComentariosEventosRepository(Event_Context context)
        {
            _context = context;
        }

        public ComentariosEventos BuscarPorIdUsuario(Guid IdUsuarios, Guid IdEventos)
        {
            try
            {
                return _context.ComentariosEventos
                    .Select(c => new ComentariosEventos
                    {
                        IdComentarioEvento = c.IdComentarioEvento,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuarios = new Usuarios
                        {
                            Nome = c.Usuarios!.Nome
                        },

                        Eventos = new Eventos
                        {
                            NomeEvento = c.Eventos!.NomeEvento,
                        }

                    }).FirstOrDefault(c => c.IdUsuario == IdUsuarios && c.IdEvento == IdEventos)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(ComentariosEventos comentarioEvento)
        {
            try
            {
                comentarioEvento.IdComentarioEvento = Guid.NewGuid();

                _context.ComentariosEventos.Add(comentarioEvento);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

      

        public void Delete(Guid Id)
        {
            try
            {
                ComentariosEventos comentarioEventoBuscado = _context.ComentariosEventos.Find(Id)!;

                if (comentarioEventoBuscado != null)
                {
                    _context.ComentariosEventos.Remove(comentarioEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ComentariosEventos> Listar(Guid Id)
        {
            try
            {
                return _context.ComentariosEventos
                    .Select(c => new ComentariosEventos
                    {
                        IdComentarioEvento = c.IdComentarioEvento,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuarios = new Usuarios
                        {
                            Nome = c.Usuarios!.Nome
                        },

                        Eventos = new Eventos
                        {
                            NomeEvento = c.Eventos!.NomeEvento,
                        }

                    }).Where(c => c.IdEvento == Id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentariosEventos> ListarSomenteExibe(Guid id)
        {
            try
            {
                return _context.ComentariosEventos
                    .Select(c => new ComentariosEventos
                    {
                        IdComentarioEvento = c.IdComentarioEvento,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuarios = new Usuarios
                        {
                            Nome = c.Usuarios!.Nome
                        },

                        Eventos = new Eventos
                        {
                            NomeEvento = c.Eventos!.NomeEvento,
                        }

                    }).Where(c => c.Exibe == true && c.IdEvento == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
    


    


