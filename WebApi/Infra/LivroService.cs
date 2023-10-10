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

   public async Task<ServiceResponse<IEnumerable<Livro>>> CreateLivroAsync(Livro livro)
    {
        var serviceResponse = new ServiceResponse<IEnumerable<Livro>>();

        try
        {
            using (var con = new SqlConnection(_getconnection))
            {
                var sql = "INSERT INTO Livros (titulo, autor) VALUES (@Titulo, @Autor)";
                await con.ExecuteAsync(sql, livro);

                var pinto = await con.QueryAsync<Livro>("select * from Livros");
                serviceResponse.Dados = pinto;
            }
        }
        catch (Exception x)
        {
            serviceResponse.Sucesso = false;
            serviceResponse.Mensagem = "Ocorreu um erro ao criar o livro.";
        }

    return serviceResponse;
}



public async Task<ServiceResponse<IEnumerable<Livro>>> DeleteLivroAsync(int LivroId)
{
    var serviceResponse = new ServiceResponse<IEnumerable<Livro>>();
    
    try
    {
        using (var con = new SqlConnection(_getconnection))
        {
            var sql = "delete from Livros where id = @id";
            await con.ExecuteAsync(sql, new { id = LivroId });
            
            var livros = await con.QueryAsync<Livro>("select * from Livros");
            serviceResponse.Dados = livros;
        }
    }
    catch (Exception x)
    {
        serviceResponse.Sucesso = false;
        serviceResponse.Mensagem = "Ocorreu um erro ao excluir o livro.";
    }

    return serviceResponse;
}

public async Task<ServiceResponse<IEnumerable<Livro>>> GetAllLivrosAsync(int skip, int take)
{
    var serviceResponse = new ServiceResponse<IEnumerable<Livro>>();

    try
    {
        using (var con = new SqlConnection(_getconnection))
        {
            var allLivros = await con.QueryAsync<Livro>("SELECT * FROM Livros");
            serviceResponse.Dados = allLivros.Skip(skip).Take(take);
        }
    }
    catch (Exception x)
    {
        serviceResponse.Sucesso = false;
        serviceResponse.Mensagem = "Ocorreu um erro ao buscar os livros.";
    }
    
    return serviceResponse;
}

public async Task<double> CountLivrosInDatabase()
{
    using(var con = new SqlConnection(_getconnection))
    {
        var count = await con.ExecuteScalarAsync<double>("SELECT COUNT(*) FROM Livros");
        return count;
    }
}


public async Task<ServiceResponse<Livro>> GetLivroByIdAsync(int LivroId)
{
    var serviceResponse = new ServiceResponse<Livro>();

    try
    {
        using (var con = new SqlConnection(_getconnection))
        {
            var sql = $"select * from Livros where id = {LivroId}";
            var livro = await con.QueryFirstOrDefaultAsync<Livro>(sql);
            
            if (livro == null)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Livro não encontrado.";
            }
            else
            {
                serviceResponse.Dados = livro;
            }
        }
    }
    catch (Exception x)
    {
        serviceResponse.Sucesso = false;
        serviceResponse.Mensagem = "Ocorreu um erro ao buscar o livro.";
    }

    return serviceResponse;
}

public async Task<ServiceResponse<IEnumerable<Livro>>> UpdateLivroAsync(Livro livro)
{
    var serviceResponse = new ServiceResponse<IEnumerable<Livro>>();

    try
    {
        using(var con = new SqlConnection(_getconnection))
        {
            var sql = "update Livros set titulo = @Titulo, autor = @Autor where id = @Id";
            await con.ExecuteAsync(sql, livro);
            
            var livros = await con.QueryAsync<Livro>("select * from Livros");
            serviceResponse.Dados = livros;
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