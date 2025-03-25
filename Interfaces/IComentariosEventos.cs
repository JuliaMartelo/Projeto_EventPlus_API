using Projeto_Event_.Domains;
using Projeto_Event_.Repository;

namespace Projeto_Event_.Interfaces
{
    public interface IComentariosEventos
    {
        void Cadastrar(ComentariosEventos novoComentario);

        ComentariosEventos BuscarPorIdUsuario(Guid IdUsuarios, Guid IdEventos);

        List<ComentariosEventos>Listar(Guid Id);

        void Delete(Guid IdComentariosEventos);
        
    }
}

