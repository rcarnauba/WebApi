using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.MOD.Usuario
{
    public class UsuarioSessaoMOD
    {
        public int CodigoUsuarioSessao { get; set; }
        public int CodigoUsuario { get; set; }
        public string Token { get; set; }
        public DateTime DataGeracao { get; set; }
    }
}
