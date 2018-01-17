using FCamara.MOD.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.Service.Interfaces.Produto
{
    public interface IProdutoService
    {
        List<ProdutoMOD> ListarProdutos();
    }
}
