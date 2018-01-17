using FCamara.MOD.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.Service.Autenticacao.Usuario.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioMOD AutenticarUsuario(string email, string senha);
    }
}
