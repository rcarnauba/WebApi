using FCamara.MOD.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.DAL.Usuario.Interfaces
{
    public interface IUsuarioDAL
    {
        UsuarioMOD AutenticarUsuario(string email, string senha);
        int InserirUsuario(UsuarioMOD usuarioMod);
    }
}
