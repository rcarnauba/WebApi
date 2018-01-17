using FCamara.MOD.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.DAL.Usuario.Interfaces
{
    public interface IUsuarioSessaoDAL
    {
        int InserirUsuarioSessao(UsuarioSessaoMOD usuarioSessao);
        bool AtualizarUsuarioSessao(string token, int codigoUsuario);
        bool ExcluirUsuarioSessao(int codigoUsuarioSessao);
        UsuarioSessaoMOD VerificarUsuarioSessao(string token, int codigoUsuario);
    }
}
