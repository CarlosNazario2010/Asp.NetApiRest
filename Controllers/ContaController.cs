using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MinhaAPI.Models;

/**Controller que faz o login do usuario e gera o token JWT para as proximas requisicoes
 * No caso foi simulado um usuario admin e senha admin, sem pega-lo efetivamente do banco de dados 
 */
namespace MinhaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Apenas um teste. O correto seria pegar usuario e senha do banco
            if (login.Login == "admin" && login.Senha == "admin") 
            {
                var token = GerarTokenJWT();
                return Ok(token);
            }

            return BadRequest(new {mensagem = "Credenciais Invalidas. Verifique o nome e senha digitados" });    
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
