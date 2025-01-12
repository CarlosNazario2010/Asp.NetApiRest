using MinhaAPI.Models;

namespace MinhaAPI.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adicionar(UsuarioModel model);
        Task<UsuarioModel> Atualizar(UsuarioModel model, int id);
        Task<bool> Apagar(int id);
    }
}
