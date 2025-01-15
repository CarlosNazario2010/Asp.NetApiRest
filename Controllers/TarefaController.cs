using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhaAPI.Models;
using MinhaAPI.Repositorios.Interfaces;

namespace MinhaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public TarefaController(ITarefaRepositorio tarefaRepositorio) 
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> BuscarTodosUsuarios()
        {
            List<TarefaModel> tarefas = await _tarefaRepositorio.BuscarTodasTarefas();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
        {
            TarefaModel tarefa = await _tarefaRepositorio.BuscarPorId(id);

            if (tarefa == null)
                return NotFound(new { message = "Tarefa nao encontrada." });

            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefa)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Tarefa invalida." });

            TarefaModel tarefaCadastrada = await _tarefaRepositorio.Adicionar(tarefa);
            return Ok(tarefaCadastrada);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefa, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Tarefa invalida." });

            TarefaModel tarefaAtualizada = await _tarefaRepositorio.Atualizar(tarefa, id);

            if (tarefaAtualizada == null)
                return NotFound(new { message = "Tarefa nao encontrada." });

            return Ok(tarefaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> Apagar(int id)
        {
            bool apagada = await _tarefaRepositorio.Apagar(id);

            if (!apagada)
                return NotFound(new { message = "Tarefa nao encontrada." });

            return Ok(apagada);    
        }
    }
}
