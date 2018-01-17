using FCamara.MOD.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.DAL.Produto.Interfaces
{
    public interface IProdutoDAL
    {
        List<ProdutoMOD> ListarProdutos(bool ativo);
        int InserirProduto(ProdutoMOD produtoMod);
    }
}
