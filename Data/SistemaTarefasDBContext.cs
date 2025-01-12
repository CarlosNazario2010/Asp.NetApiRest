using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data.Map;
using MinhaAPI.Models;

namespace MinhaAPI.Data
{
    /**Classe que define o contexto do banco de dados, responsavel por mapear as tabelas
     * e realizar as configuracoes para gerar as migrations para o banco de dados
     * 
     * Para gerar e rodar a migration no Package Manegement Console:
     * Add-Migration MensagemDeIdentificacao -Context SistemaTarefasDBContext
     * e
     * Update-Database -Context SistemaTarefasDBContext
     */
    public class SistemaTarefasDBContext : DbContext
    {
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options)
            : base(options) { }

        public DbSet<UsuarioModel> Usuarios { get; set; }   
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
