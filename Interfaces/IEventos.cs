using Projeto_Event_.Domains;

namespace Projeto_Event_.Interfaces
{
    public interface IEventos
    {
        void Cadastrar(Eventos eventos);
        Eventos BuscarPorId(Guid Id);
        List<Eventos> Listar();
        void Atualizar(Guid Id, Eventos eventos);
        void Deletar(Guid Id);

        List<Eventos> listarProximoEvento();
        List<Eventos> listarId(Guid Id);
    }
}
