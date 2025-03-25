using Projeto_Event_.Context;
using Projeto_Event_.Domains;
using Projeto_Event_.Interfaces;

namespace Projeto_Event_.Repository
{
    public class PresencasRepostory : IPresencas

    {
        private readonly Event_Context? _context;

        public PresencasRepostory(Event_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid Id, Presencas presencas)
        {
            try
            {
                Presencas presencaEventoBuscado = _context.Presencas.Find(Id)!;

                if (presencaEventoBuscado != null)
                {
                    if (presencaEventoBuscado.Situacao)
                    {
                        presencaEventoBuscado.Situacao = false;
                    }
                    else
                    {
                        presencaEventoBuscado.Situacao = true;
                    }

                }

                _context.Presencas.Update(presencaEventoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Presencas BuscarPorId(Guid Id)
        {
            try
            {
                return _context.Presencas.Select(p => new Presencas
                    {
                        IdPresenca = p.IdPresenca,
                        Situacao = p.Situacao,

                        Eventos = new Eventos
                        {
                            IdEvento = p.IdEventos!,
                            DataEvento = p.Eventos!.DataEvento,
                            NomeEvento = p.Eventos.NomeEvento,
                            Descricao = p.Eventos.Descricao,

                            Instituicao = new Instituicoes
                            {
                                IdInstituicao = p.Eventos.Instituicao!.IdInstituicao,
                                NomeFantasia = p.Eventos.Instituicao!.NomeFantasia
                            }
                        }

                    }).FirstOrDefault(p => p.IdEventos == Id)!;
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
                Presencas presencaEventoBuscado = _context.Presencas.Find(Id)!;

                if (presencaEventoBuscado != null)
                {
                    _context.Presencas.Remove(presencaEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Inscricao(Presencas inscricao)
        {
            try
            {
                inscricao.IdPresenca = Guid.NewGuid();

                _context.Presencas.Add(inscricao);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Presencas> Listar()
        {

            try
            {
                return _context.Presencas
                    .Select(p => new Presencas
                    {
                        IdPresenca = p.IdPresenca,
                        Situacao = p.Situacao,

                        Eventos = new Eventos
                        {
                            IdEvento = p.IdEventos,
                            DataEvento = p.Eventos!.DataEvento,
                            NomeEvento = p.Eventos.NomeEvento,
                            Descricao = p.Eventos.Descricao,

                            Instituicao = new Instituicoes
                            {
                                IdInstituicao = p.Eventos.Instituicao!.IdInstituicao,
                                NomeFantasia = p.Eventos.Instituicao!.NomeFantasia
                            }
                        }

                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Presencas> ListarMinhas(Guid Id)
        {
            return _context.Presencas.Select(p => new Presencas
            {
                IdPresenca = p.IdPresenca,
                Situacao = p.Situacao,
                IdUsuario = p.IdUsuario,
                IdEventos = p.IdEventos,


                Eventos = new Eventos
                {
                    IdEvento = p.IdEventos,
                    DataEvento = p.Eventos!.DataEvento,
                    NomeEvento = p.Eventos!.NomeEvento,
                    Descricao = p.Eventos!.Descricao,

                    Instituicao = new Instituicoes
                    {
                        IdInstituicao = p.Eventos!.InstituicoesID,
                    }
                }
            })
                 .Where(p => p.IdUsuario == Id).ToList();
        }
    }
}
