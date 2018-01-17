using Microsoft.VisualStudio.TestTools.UnitTesting;
using FCamara.DAL.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCamara.MOD.Produto;

namespace FCamara.DAL.Produto.Tests
{
    [TestClass()]
    public class ProdutoDALTests
    {
        [TestMethod()]
        public void InserirProdutoTest()
        {
            ProdutoDAL produtoDal = new ProdutoDAL();
            List<ProdutoMOD> listProdutoMOD = new List<ProdutoMOD>();
            listProdutoMOD = PreparaModProduto();

            foreach (var item in listProdutoMOD)
            {
                if (produtoDal.InserirProduto(item) <= 0)
                    Assert.Fail();
            }

        }

        [TestMethod()]
        public void ListarProdutosTest()
        {
            Assert.Fail();
        }

        private List<ProdutoMOD> PreparaModProduto()
        {
            List<ProdutoMOD> listProdutoMOD = new List<ProdutoMOD>();
            ProdutoMOD produtoMOD;

            produtoMOD = new ProdutoMOD();
            produtoMOD.CategoriaProduto = 1;
            produtoMOD.DataCadastro = DateTime.Now;
            produtoMOD.MarcaProduto = "nike";
            produtoMOD.NomeProduto = "Tenis";
            produtoMOD.DescricaoProduto = "Tenis para running";
            produtoMOD.Valor = 10.00M;
            produtoMOD.Ativo = true;
        
            listProdutoMOD.Add(produtoMOD);

            produtoMOD = new ProdutoMOD();
            produtoMOD.CategoriaProduto = 1;
            produtoMOD.DataCadastro = DateTime.Now;
            produtoMOD.MarcaProduto = "Addidas";
            produtoMOD.NomeProduto = "Bola";
            produtoMOD.DescricaoProduto = "Bola para futebold de salão";
            produtoMOD.Valor = 12.00M;
            produtoMOD.Ativo = true;
            listProdutoMOD.Add(produtoMOD);

            produtoMOD = new ProdutoMOD();
            produtoMOD.CategoriaProduto = 1;
            produtoMOD.DataCadastro = DateTime.Now;
            produtoMOD.MarcaProduto = "Umbro";
            produtoMOD.NomeProduto = "Camiseta";
            produtoMOD.DescricaoProduto = "Camiseta para jogo";
            produtoMOD.Valor = 10.00M;
            produtoMOD.Ativo = true;
            listProdutoMOD.Add(produtoMOD);
            return listProdutoMOD;
        }
    }
}