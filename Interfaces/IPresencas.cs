using Projeto_Event_.Domains;

namespace Projeto_Event_.Interfaces
{
    public interface IPresencas
    {
        void Incricao(Presencas inscricao;
        Presencas BuscarPorId(Guid Id);
        List<Presencas> Listar();
        void Atualizar(Guid Id, Presencas presencas);
        void Deletar(Guid Id);
        List<Presencas> ListarMinhas(Guid Id);
    }
}
