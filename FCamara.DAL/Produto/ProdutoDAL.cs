using FCamara.DAL.Produto.Interfaces;
using FCamara.MOD.Produto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace FCamara.DAL.Produto
{
    public class ProdutoDAL : IProdutoDAL
    {
        public int InserirProduto(ProdutoMOD produtoMod)
        {
            using (IDbConnection conexao = new SqlConnection(BancoDados.ConnectionString))
            {
                conexao.Open();

                string query = @" 

                INSERT INTO [Produto]
                (
                    [NomeProduto],
                    [DescricaoProduto],
                    [CategoriaProduto],
                    [DataCadastro],
                    [Valor],
                    [Ativo],
                    [MarcaProduto]
                )
                OUTPUT INSERTED.[CodigoProduto]
                VALUES
                (
                    @NomeProduto,
                    @DescricaoProduto,
                    @CategoriaProduto,
                    @DataCadastro,
                    @Valor,
                    @Ativo,
                    @MarcaProduto
                ) ";

                return conexao.Query<int>(query, new
                {
                    NomeProduto =produtoMod.NomeProduto,
                    DescricaoProduto = produtoMod.DescricaoProduto,
                    CategoriaProduto = produtoMod.CategoriaProduto,
                    DataCadastro = DateTime.Now,
                    Valor = produtoMod.Valor,
                    Ativo = 1,
                    MarcaProduto =produtoMod.MarcaProduto                
                    }).Single();
                }
        }

        public List<ProdutoMOD> ListarProdutos(bool ativo)
        {
            using (IDbConnection conn = new SqlConnection(BancoDados.ConnectionString))
            {
                conn.Open();
                string query =

                @"
                SELECT 
	                CodigoProduto,
	                NomeProduto,
	                DescricaoProduto,
	                CategoriaProduto,
	                DataCadastro,
	                Valor,
	                Ativo,
	                MarcaProduto 
                FROM Produto		
                Where Ativo = @Ativo ";

                return conn.Query<ProdutoMOD>(query, new { Ativo = ativo}).ToList();
            }
        }     
    }
}
