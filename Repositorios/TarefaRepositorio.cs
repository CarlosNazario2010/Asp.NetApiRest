﻿using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data;
using MinhaAPI.Models;
using MinhaAPI.Repositorios.Interfaces;

/**Implementacao do metodos de tarefa descritos na Interface de Tarefas
 * Utiliza o contexto do banco de dados do EntityFramework ORM para realizar a manipulacao dos dados
 */

namespace MinhaAPI.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContext;

        public TarefaRepositorio(SistemaTarefasDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            TarefaModel tarefa = await _dbContext.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

            if (tarefa == null)
            {
                throw new Exception($"Tarefa para o ID: {id} nao foi encontrada");
            }

            return tarefa;
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            List<TarefaModel> tarefas = await _dbContext.Tarefas.ToListAsync();

            if (tarefas == null)
            {
                throw new Exception("Lista de Tarefas esta vazia");
            }

            return tarefas;
        }

        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            
            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} nao foi encontrada");
            }
            
            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;

            _dbContext.Tarefas.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} nao foi encontrado");
            }
            _dbContext.Tarefas.Remove(tarefaPorId);   
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}