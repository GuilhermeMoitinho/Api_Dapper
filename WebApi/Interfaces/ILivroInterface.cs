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
        Task<IEnumerable<Livro>>  GetAllLivrosAsync(int skip, int take);
        Task<Livro>  GetLivroByIdAsync(int id);
        Task<Livro> CreateLivroAsync(Livro livro);
        Task<ServiceResponse<IEnumerable<Livro>>> UpdateLivroAsync(Livro livro);
        Task DeleteLivroAsync(int LivroId);

        Task<double> CountLivrosInDatabase();
    }
}
