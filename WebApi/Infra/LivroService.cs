using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using WebApi.Models;

namespace WebApi.Services.LivroService
{
    public class LivroService : ILivroInterface
    {
        private readonly IConfiguration _config;
        private readonly string _getconnection;
        public LivroService(IConfiguration config)
        {
            _config = config;
            _getconnection = _config.GetConnectionString("ConexaoPadrao");
            
        }

       public async Task<IEnumerable<Livro>> CreateLivro(Livro livro)
        {
            using (var con = new SqlConnection(_getconnection))
            {
                var sql = "INSERT INTO Livros (titulo, autor) VALUES (@Titulo, @Autor)";
                await con.ExecuteAsync(sql, livro);

                return await con.QueryAsync<Livro>("select * from Livros");
            }
        }


        public async Task<IEnumerable<Livro>> DeleteLivro(int Id)
        {
            using (var con = new SqlConnection(_getconnection))
            {
                var sql = "delete from Livros where id = @id";
                await con.ExecuteAsync(sql, new {id = Id});                

                return await con.QueryAsync<Livro>("select * from Livros");
            }
        }

        public async Task<IEnumerable<Livro>> GetAllLivros()
        {
            using (var con = new SqlConnection(_getconnection))
            {
                var sql = "select * from Livros";
                return await con.QueryAsync<Livro>(sql); 
            }
        }

        public async Task<Livro> GetLivroById(int LivroId)
        {
            using (var con = new SqlConnection(_getconnection))
            {
                var sql = $"select * from Livros where id = {LivroId}";

                return await con.QueryFirstOrDefaultAsync<Livro>(sql);
            }
        }

        public async Task<IEnumerable<Livro>> UpdateLivro(Livro livro)
        {
            using(var con = new SqlConnection(_getconnection))
            {
                var sql = "update Livros set titulo = @Titulo, autor = @Autor where id = @Id";
                await con.ExecuteAsync(sql, livro);

                return await con.QueryAsync<Livro>("select * from Livros");
            }
        }
    }
}