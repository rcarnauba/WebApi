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
    public class UsuarioSessaoDALTests
    {
        [TestMethod()]
        public void VerificarUsuarioSessaoTest()
        {
            UsuarioSessaoDAL usuarioSessaoDAL = new UsuarioSessaoDAL();
            UsuarioSessaoMOD usuarioSessaoMOD = new UsuarioSessaoMOD();

            usuarioSessaoMOD = usuarioSessaoDAL.VerificarUsuarioSessao("das12312312315zxzxczxczxdasd", 8);
        }

        [TestMethod()]
        public void AtualizarUsuarioSessaoTest()
        {
            UsuarioSessaoDAL usuarioSessaoDAL = new UsuarioSessaoDAL();
            if(usuarioSessaoDAL.AtualizarUsuarioSessao("das12312312315zxzxczxczxdasd", 8))
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod()]
        public void ExcluirUsuarioSessaoTest()
        {
            UsuarioSessaoDAL usuarioSessaoDAL = new UsuarioSessaoDAL();
            if (usuarioSessaoDAL.ExcluirUsuarioSessao(3))
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod()]
        public void InserirUsuarioSessaoTest()
        {
            UsuarioSessaoDAL usuarioSessaoDAL = new UsuarioSessaoDAL();
            UsuarioSessaoMOD usuarioSessaoMOD = new UsuarioSessaoMOD();

            usuarioSessaoMOD.CodigoUsuario = 8;
            usuarioSessaoMOD.DataGeracao = DateTime.Now;
            usuarioSessaoMOD.Token = "das12312312315zxzxczxczxdasd" ;

            usuarioSessaoDAL.InserirUsuarioSessao(usuarioSessaoMOD);

        }
    }
}