using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MinhaAPI.Models;
using MinhaAPI.Repositorios.Interfaces;

/**Controller que faz o login do usuario e gera o token JWT para as proximas requisicoes
 * No caso foi simulado um usuario admin e senha admin, sem pega-lo efetivamente do banco de dados 
 */
namespace MinhaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepositorio _loginRepositorio;
        public LoginController(ILoginRepositorio loginRepositorio)
        {
            _loginRepositorio = loginRepositorio;
        }

        [HttpPost("/logar")]
        public async Task<ActionResult<LoginModel>> Login([FromBody] LoginModel login)
        {
            LoginModel loginBuscado = await _loginRepositorio.Logar(login);

            if (loginBuscado.Login == login.Login && loginBuscado.Senha == login.Senha)
            {
                var token = GerarTokenJWT();
                return Ok(token);
            }

            return BadRequest(new { mensagem = "Credenciais Invalidas. Verifique o nome e senha digitados" });
        }

        [HttpPost("/cadastrar")]
        public async Task<ActionResult<LoginModel>> Cadastrar([FromBody] LoginModel login)
        {
            await _loginRepositorio.Cadastrar(login);

            var token = GerarTokenJWT();
            return Ok(token);
        }

        private string GerarTokenJWT()
        {
            // Chave do Program.cs
            string chaveSecreta = "8bcb07d5-489e-47e0-ad88-c5988d6428f9";

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            //Dados que iram dentro do payload do token. Apenas teste sem pegar dados do banco
            var claims = new[]
            {
                new Claim("login", "admmin"),
                new Claim("nome", "Administrador do Sistema")
            };

            // Issuer e Audience tambem do Program.cs
            var token = new JwtSecurityToken(
                issuer: "suaEmpresa",
                audience: "suaAplicacao",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credencial
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
