using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using WebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApi.Domain.Models.Service;

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

        public async Task<Livro> CreateLivroAsync(Livro livro)
        {
            using (var con = new SqlConnection(_getconnection))
            {
                var sql = "INSERT INTO Livros (titulo, autor) VALUES (@Titulo, @Autor); SELECT SCOPE_IDENTITY()";
                int id = await con.ExecuteScalarAsync<int>(sql, livro);
                livro.Id = id;
                return livro;
            }
        }




        public async Task DeleteLivroAsync(int LivroId)
        {
            using (var con = new SqlConnection(_getconnection))
            {
                var sql = "DELETE FROM Livros WHERE id = @id";
                await con.ExecuteAsync(sql, new { id = LivroId });
            }
        }


        public async Task<IEnumerable<Livro>> GetAllLivrosAsync(int skip, int take)
        {
            using (var con = new SqlConnection(_getconnection))
            {
              var livros = await con.QueryAsync<Livro>("SELECT * FROM Livros");
              return livros;
            } 
        }

        public async Task<double> CountLivrosInDatabase()
        {
            using(var con = new SqlConnection(_getconnection))
            {
                var count = await con.ExecuteScalarAsync<double>("SELECT COUNT(*) FROM Livros");
                return count;
            }
        }


public async  Task<Livro> GetLivroByIdAsync(int id)
{

        using (var con = new SqlConnection(_getconnection))
        {
            var sql = $"select * from Livros where id = {id}";
           return await con.QueryFirstOrDefaultAsync<Livro>(sql);
        }

}

        public async Task<ServiceResponse<IEnumerable<Livro>>> UpdateLivroAsync(Livro livro)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<Livro>>();

            try
            {
                using (var con = new SqlConnection(_getconnection))
                {
                    var sql = "UPDATE Livros SET titulo = @Titulo, autor = @Autor WHERE id = @Id";
                    await con.ExecuteAsync(sql, livro);

                    serviceResponse.Mensagem = "Edição concluída com sucesso!";
                }
            }
            catch (Exception x)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Ocorreu um erro ao atualizar o livro.";
            }

            return serviceResponse;
        }


    }
}