using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services.LivroService
{
    public interface ILivroInterface
    {
        Task<IEnumerable<Livro>> GetAllLivrosAsync(int skip, int take);
        Task<Livro> GetLivroByIdAsync(int LivroId);
        Task<IEnumerable<Livro>> CreateLivroAsync(Livro livro);
        Task<IEnumerable<Livro>> UpdateLivroAsync(Livro livro);
        Task<IEnumerable<Livro>> DeleteLivroAsync(int LivroId);
    }
}