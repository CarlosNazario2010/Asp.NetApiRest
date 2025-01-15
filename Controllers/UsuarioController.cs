using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhaAPI.Models;
using MinhaAPI.Repositorios.Interfaces;

namespace MinhaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio) 
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);

            if (usuario == null)
            {
                return NotFound(new { message = "Usuario nao encontrado." });
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuario)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(new { message = "Usuario Invalido." });
            }

            UsuarioModel usuarioCadastrado = await _usuarioRepositorio.Adicionar(usuario);
            return Ok(usuarioCadastrado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuario, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Usuario invalido." });
            }

            UsuarioModel usuarioAtualizado = await _usuarioRepositorio.Atualizar(usuario, id);
            
            if (usuarioAtualizado == null)
            {
                return NotFound(new { message = "Usuario nao encontrado." });
            }
            
            return Ok(usuarioAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(id);
            
            if (!apagado) 
            { 
                return NotFound(new { message = "Usuario nao encontrado." }); 
            }
            
            return Ok(apagado);    
        }
    }
}
