using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using FCamara.Service.Autenticacao.Token.Interfaces;
using FCamara.Service.Interfaces.Produto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace FCamara.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Produto")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _iProdutoService;
        private readonly ITokenService _iTokenService;

        public ProdutoController(IProdutoService iProdutoService, ITokenService iTokenService)
        {
            _iProdutoService = iProdutoService;
            _iTokenService = iTokenService;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            string token = String.Empty;
            StringValues valor;

            if (Request.Headers.TryGetValue("Authorization", out valor))
            {
                if (!String.IsNullOrEmpty(_iTokenService.ValidarToken(valor.ToString())))
                {
                    return Ok(_iProdutoService.ListarProdutos());
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return NotFound("Token não encontrado!");
            }
        }
    }
}
