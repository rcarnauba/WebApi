using Microsoft.VisualStudio.TestTools.UnitTesting;
using FCamara.DAL.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCamara.MOD.Usuario;

namespace FCamara.DAL.Usuario.Tests
{
    [TestClass()]
    public class UsuarioTests
    {

        [TestMethod()]
        public void InserirUsuarioTest()
        {
            UsuarioDAL usuario = new UsuarioDAL();
            UsuarioMOD usuarioMOD = new UsuarioMOD();
            usuarioMOD.Ativo = true;
            usuarioMOD.Nome = "Ricardo";
            usuarioMOD.Email = "ricardo.carnauba@gmail.com";
            usuarioMOD.Senha = "teste";

            try
            { 
                int codigoUsuario = 0;

                codigoUsuario = usuario.InserirUsuario(usuarioMOD);

                if (codigoUsuario > 0)
                {
                    usuarioMOD = AutenticaUsuario("ricardo.carnauba@gmail.com", "teste");
                }
                else
                    Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        private UsuarioMOD AutenticaUsuario (string email , string senha)
        {
            UsuarioDAL usuario = new UsuarioDAL();
            UsuarioMOD usuarioMOD = new UsuarioMOD();
            usuarioMOD = usuario.AutenticarUsuario(email, senha);
            return usuarioMOD;
        }
    }
}