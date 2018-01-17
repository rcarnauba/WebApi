using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.Service.Autenticacao.Token.Interfaces
{
    public interface ITokenService
    {
        string GerarToken(string email, int tempoExpiracao);
        string ValidarToken(string tokenToValidate);
    }
}
