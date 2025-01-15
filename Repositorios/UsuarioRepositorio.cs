using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data;
using MinhaAPI.Models;
using MinhaAPI.Repositorios.Interfaces;

namespace MinhaAPI.Repositorios
{
    /**Implementacao do metodos de usuario descritos na Interface de Usuario
     * Utiliza o contexto do banco de dados do EntityFramework ORM para realizar a manipulacao dos dados
     */
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContext;

        public UsuarioRepositorio(SistemaTarefasDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            return usuario;
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _dbContext.Usuarios.ToListAsync();
            return usuarios;
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            _dbContext.Usuarios.Remove(usuarioPorId);   
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
