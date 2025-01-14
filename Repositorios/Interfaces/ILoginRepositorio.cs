using MinhaAPI.Models;

namespace MinhaAPI.Repositorios.Interfaces
{
    public interface ILoginRepositorio
    {
        Task<LoginModel> Logar(LoginModel model);
        Task<LoginModel> Cadastrar(LoginModel model);
    }
}
