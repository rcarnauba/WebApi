using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using FCamara.API.Model;
using FCamara.Service.Autenticacao.Token.Interfaces;
using FCamara.Service.Autenticacao.Usuario.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FCamara.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Autenticacao")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AutenticacaoController : Controller
    {
        private readonly IUsuarioService _iUsuarioBSService;
        private readonly ITokenService _iTokenService;

        public AutenticacaoController(IUsuarioService iUsuarioBSService, ITokenService iTokenService)
        {
            _iUsuarioBSService = iUsuarioBSService;
            _iTokenService = iTokenService;
        }

        [HttpPost]
        public IActionResult AutenticaUsuario([FromBody] AutenticacaoModel autenticacao)
        {
            string token = string.Empty;
            if (_iUsuarioBSService.AutenticarUsuario(autenticacao.Email, autenticacao.Senha) != null)          
                token = _iTokenService.GerarToken(autenticacao.Email, 1);

            if (!String.IsNullOrEmpty(token))
                return Ok(token);
            else
                return NotFound("Credenciais inválidas!");
        }
    }
}
