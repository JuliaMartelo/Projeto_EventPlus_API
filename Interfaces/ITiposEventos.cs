using Projeto_Event_.Domains;

namespace Projeto_Event_.Interfaces
{
    public interface ITiposEventos
    {
        void Cadastrar(TiposEventos tiposEventos);
        List<TiposEventos>Listar();
        void Atualizar(Guid Id, TiposEventos tiposEventos);
        void Deletar(Guid Id);
        TiposEventos BuscarPorId(Guid Id);
    }
}
