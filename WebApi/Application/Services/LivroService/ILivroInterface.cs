using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Domain.Models.Service;
using WebApi.Models;

namespace WebApi.Services.LivroService
{
    public interface ILivroInterface
    {
        Task<ServiceResponse<IEnumerable<Livro>>> GetAllLivrosAsync(int skip, int take);
        Task<ServiceResponse<Livro>> GetLivroByIdAsync(int LivroId);
        Task<ServiceResponse<IEnumerable<Livro>>> CreateLivroAsync(Livro livro);
        Task<ServiceResponse<IEnumerable<Livro>>> UpdateLivroAsync(Livro livro);
        Task<ServiceResponse<IEnumerable<Livro>>> DeleteLivroAsync(int LivroId);

        Task<double> CountLivrosInDatabase();
    }
}
