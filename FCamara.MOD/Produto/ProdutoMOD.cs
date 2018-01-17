using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCamara.MOD.Produto
{
    public class ProdutoMOD
    {
        public int CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int CategoriaProduto { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public string MarcaProduto { get; set; }
    }
}
