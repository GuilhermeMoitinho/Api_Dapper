using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Models.Service;
using WebApi.Models;
using WebApi.Services.LivroService;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface LivroInterface)
        {
            _livroInterface = LivroInterface;
        }

        [HttpGet("skip/{skip:int}/take/{take}")]
        public async Task<ServiceResponse<IEnumerable<Livro>>> GetAllLivrosAsync(int skip = 0, int take = 15)
        {
            return await _livroInterface.GetAllLivrosAsync(skip, take);
        }




        [HttpGet("{id}")]
        public async Task<ServiceResponse<Livro>> GetLivroByIdAsync(int id)
        {
            return await _livroInterface.GetLivroByIdAsync(id);
        }

        [HttpPost]
          public async Task<ServiceResponse<IEnumerable<Livro>>> CreateLivroAsync(Livro livro)
          {
             return await _livroInterface.CreateLivroAsync(livro);
          }


        [HttpPut]
          public async Task<ServiceResponse<IEnumerable<Livro>>> UpdateLivroAsync(Livro livro)
          {
             return await _livroInterface.UpdateLivroAsync(livro);
          }

          [HttpDelete("{id}")]
           public async Task<ServiceResponse<IEnumerable<Livro>>> DeleteLivroAsync(int id)
           {
              return await _livroInterface.DeleteLivroAsync(id);
           }

    }
}