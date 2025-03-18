using Projeto_Event_.Domains;

namespace Projeto_Event_.Interfaces
{
    public interface IComentariosEventos
    {
        void Cadastrar(ComentariosEventos comentarioseventos);

        ComentariosEventos BuscarPorIdUsuario(Guid IdUsuarios, Guid IdEventos);

        List<ComentariosEventos>Listar(Guid Id);

        void Delete(Guid IdComentariosEventos);
    }
}

