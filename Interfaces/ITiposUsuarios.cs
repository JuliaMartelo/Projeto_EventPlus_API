using Projeto_Event_.Domains;

namespace Projeto_Event_.Interfaces
{
    public interface ITiposUsuarios
    {
        void Cadastrar(TiposUsuarios tiposUsuarios);
        List<TiposUsuarios> Listar();
        void Atualizar(Guid Id, TiposUsuarios tiposusuarios);
        void Deletar(Guid Id);
        TiposUsuarios BuscarPorId(Guid Id);
    }
}
