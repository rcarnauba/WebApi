using FCamara.DAL.Usuario.Interfaces;
using FCamara.MOD.Usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace FCamara.DAL.Usuario
{
    public class UsuarioDAL : IUsuarioDAL
    {
        public UsuarioMOD AutenticarUsuario(string email, string senha)
        {
            using (IDbConnection conn = new SqlConnection(BancoDados.ConnectionString))
            {
                conn.Open();

                string query = @"
                SELECT 
                    CodigoUsuario,
	                Nome,
                    Email,
                    '' AS Senha,
                    Ativo,
                    DataCadastro
	                FROM  [Usuario] 
                WHERE Email = @Email 
                AND Senha = @Senha ";

                return conn.QueryFirstOrDefault<UsuarioMOD>(query, new { email = email, senha = senha});
            }
        }

        public int InserirUsuario(UsuarioMOD usuarioMod)
        {
            using (IDbConnection conexao = new SqlConnection(BancoDados.ConnectionString))
            {
                conexao.Open();

                string query = @" 
                INSERT INTO [Usuario] 
                (
                    [Nome],
                    [Email],
                    [Senha],
                    [Ativo],
                    [DataCadastro]
                )
                OUTPUT INSERTED.[CodigoUsuario]
                VALUES
                (
                    @Nome,
                    @Email,
                    @Senha,
                    @Ativo,
                    @DataCadastro
                ) ";
               
               return conexao.QuerySingle<int>(query, new
               {
                   Nome = usuarioMod.Nome,
                   Email = usuarioMod.Email,
                   Senha = usuarioMod.Senha,
                   Ativo = 1,
                   DataCadastro = DateTime.Now
               }); 
            }
        }
    }
}

    
