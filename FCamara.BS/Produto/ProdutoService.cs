using FCamara.DAL.Produto.Interfaces;
using FCamara.MOD.Produto;
using FCamara.Service.Autenticacao.Token.Interfaces;
using FCamara.Service.Interfaces.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.Service.Produto
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoDAL _iProdutoDAL;

        public ProdutoService(IProdutoDAL iProdutoDAL)
        {
            _iProdutoDAL = iProdutoDAL;
        }

        public List<ProdutoMOD> ListarProdutos()
        {
            return _iProdutoDAL.ListarProdutos(true);
        }

    }
}
