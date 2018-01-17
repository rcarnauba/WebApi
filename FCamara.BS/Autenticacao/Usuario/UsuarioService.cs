using FCamara.DAL.Usuario.Interfaces;
using FCamara.MOD.Usuario;
using FCamara.Service.Autenticacao.Usuario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FCamara.Service.Autenticacao.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioDAL _iUsuarioDAL;

        public UsuarioService(IUsuarioDAL iUsuarioDAL)
        {
            _iUsuarioDAL = iUsuarioDAL;
        }

        public UsuarioMOD AutenticarUsuario(string email, string senha)
        {
            return _iUsuarioDAL.AutenticarUsuario(email, senha);
        }
    }
}
