using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data;
using MinhaAPI.Models;
using MinhaAPI.Repositorios.Interfaces;

namespace MinhaAPI.Repositorios
{
    public class LoginRepositorio : ILoginRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContext;

        public LoginRepositorio(SistemaTarefasDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LoginModel> Cadastrar(LoginModel login)
        {
            await _dbContext.Login.AddAsync(login);
            await _dbContext.SaveChangesAsync();
            return login;
        }

        public async Task<LoginModel> Logar(LoginModel login)
        {
            LoginModel? loginBuscado = await _dbContext.Login.FirstOrDefaultAsync(x => x.Senha == login.Senha);

            if (loginBuscado == null)
            {
                throw new Exception($"Usuario nao cadastrado ou invalido");
            }
            return loginBuscado;
        }
    }
}
