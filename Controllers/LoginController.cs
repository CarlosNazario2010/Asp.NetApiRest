using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MinhaAPI.Models;
using MinhaAPI.Repositorios.Interfaces;

/**Controller que faz o cadastramento e o login do usuario e gera o token JWT 
 * para ser usado nas proximas requisicoes
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
                var token = GerarTokenJWT(login);
                return Ok(token);
            }

            return BadRequest(new { mensagem = "Credenciais Invalidas. Verifique o nome e senha digitados" });
        }

        [HttpPost("/cadastrar")]
        public async Task<ActionResult<LoginModel>> Cadastrar([FromBody] LoginModel login)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(new { message = "Dados para o cadastramento do usuario invalidos." });
            }

            await _loginRepositorio.Cadastrar(login);

            var token = GerarTokenJWT(login);
            return Ok(token);
        }

        private string GerarTokenJWT(LoginModel login)
        {
            // Chave do Program.cs
            string chaveSecreta = "8bcb07d5-489e-47e0-ad88-c5988d6428f9";

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            string loginParaClaim = login.Login;
            string senhaParaClaim = login.Senha;

            //Dados que iram dentro do payload do token. 
            var claims = new[]
            {
                new Claim("login", loginParaClaim),
                new Claim("nome", senhaParaClaim)
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
