using API.Context;
using Clases.Comandos.Usuario;
using Clases.Models;
using Clases.Resultados;
using Clases.Resultados.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ContextBD _context;

        public UsuarioController(ContextBD context) { _context = context; }

        [HttpGet]
        [Route("api/usuario/getusuarios")]
        public async Task<ResultadoBase> GetUsuarios()
        {
            //var resultado = new ResultadoBase();
            
            //resultado.Resultado = await _context.Usuario.ToListAsync();
            //resultado.Ok = true;
            //resultado.StatusCode = 200;

            //return resultado;
        }

        [HttpPost]
        [Route("api/usuario/login")]
        public async Task<LoginResultado> Login(LoginComando comando)
        { 
            var resultado = new LoginResultado();
            var usuario = await _context.Usuario.FirstOrDefaultAsync(c => c.Email.Equals(comando.Email) 
            && c.Password.Equals(comando.Password));
            if(usuario == null)
            {
                resultado.SetError("Email o Password incorrectos");
                return resultado;
            }
            resultado.LoginResult = true;
            return resultado;
        }
    }
}
