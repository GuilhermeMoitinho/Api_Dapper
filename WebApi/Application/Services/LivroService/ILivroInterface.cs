using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services.LivroService
{
    public interface ILivroInterface
    {
        Task<IEnumerable<Livro>> GetAllLivros();
        Task<Livro> GetLivroById(int LivroId);
        Task<IEnumerable<Livro>> CreateLivro(Livro livro);
        Task<IEnumerable<Livro>> UpdateLivro(Livro livro);
        Task<IEnumerable<Livro>> DeleteLivro(int LivroId);
    }
}