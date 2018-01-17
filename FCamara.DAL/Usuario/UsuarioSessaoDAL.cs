using FCamara.DAL.Usuario.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FCamara.MOD.Usuario;

namespace FCamara.DAL.Usuario
{
    public class UsuarioSessaoDAL : IUsuarioSessaoDAL
    {
        public UsuarioSessaoMOD VerificarUsuarioSessao(string token, int codigoUsuario)
        {
            using (IDbConnection conn = new SqlConnection(BancoDados.ConnectionString))
            {
                conn.Open();

                string query = @"
                SELECT 
                    CodigoUsuarioSessao,
	                CodigoUsuario,
                    Token,
                    DataGeracao
	                FROM  [UsuarioSessao] 
                WHERE Token = @Token 
                AND CodigoUsuario = @CodigoUsuario ";

                return conn.QueryFirstOrDefault<UsuarioSessaoMOD>(query, new { Token = token, CodigoUsuario = codigoUsuario });
            }
        }

        public bool AtualizarUsuarioSessao(string token, int codigoUsuario)
        {
            using (IDbConnection conn = new SqlConnection(BancoDados.ConnectionString))
            {
                conn.Open();

                string query = @"
                UPDATE  [UsuarioSessao] 
                    SET DataGeracao = @DataGeracao
                WHERE Token = @Token 
                AND CodigoUsuario = @CodigoUsuario ";

                conn.Execute(query, new
                {
                    DataGeracao = DateTime.Now,
                    Token = token,
                    CodigoUsuario = codigoUsuario
               });

                return true;
            }
        }

        public bool ExcluirUsuarioSessao(int codigoUsuarioSessao)
        {
            using (IDbConnection conn = new SqlConnection(BancoDados.ConnectionString))
            {
                conn.Open();

                string query = @"   
                DELETE FROM [UsuarioSessao] 
                  WHERE 
                CodigoUsuarioSessao = @CodigoUsuarioSessao
                ";

                conn.Execute(query, new
                {
                    CodigoUsuarioSessao = codigoUsuarioSessao
                });

                return true;
            }
        }

        public int InserirUsuarioSessao(UsuarioSessaoMOD usuarioSessaoMod)
        {
            using (IDbConnection conn = new SqlConnection(BancoDados.ConnectionString))
            {
                conn.Open();

                string query = @" 
                INSERT INTO [UsuarioSessao] 
                (
                    [CodigoUsuario],
                    [Token],
                    [DataGeracao]
                )
                OUTPUT INSERTED.[CodigoUsuarioSessao]
                VALUES
                (
                    @CodigoUsuario,
                    @Token,
                    @DataGeracao
                ) ";

                return conn.QuerySingle<int>(query, new
                {
                    CodigoUsuario = usuarioSessaoMod.CodigoUsuario,
                    Token = usuarioSessaoMod.Token,
                    DataGeracao = usuarioSessaoMod.DataGeracao
                });
            }
        }
    }
}
