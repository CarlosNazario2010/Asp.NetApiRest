using MinhaAPI.Models;

namespace MinhaAPI.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<List<TarefaModel>> BuscarTodasTarefas();
        Task<TarefaModel> BuscarPorId(int id);
        Task<TarefaModel> Adicionar(TarefaModel model);
        Task<TarefaModel> Atualizar(TarefaModel model, int id);
        Task<bool> Apagar(int id);
    }
}
