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
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface LivroInterface)
        {
            _livroInterface = LivroInterface;
        }

       [HttpGet("skip/{skip:int}/take/{take}")]
        public async Task<IActionResult> GetAllLivrosAsync(int skip = 0, int take = 15)
        {
           var value = await _livroInterface.GetAllLivrosAsync(skip, take);
            return Ok(value);
        }




        [ActionName("GetLivroByIdAsync")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLivroByIdAsync(int id)
        {
            if(id == null) return NotFound();

            var livro = await _livroInterface.GetLivroByIdAsync(id);

            if(livro is null) return NotFound();
                    

            var retorno = new {
                Sucesso = true,
                Dados = livro,
                Mensagem = "Seu Livro foi requisitado"
            };

            return Ok(retorno);

            
        }

        [HttpPost]
        public async Task<IActionResult> CreateLivroAsync(Livro livro)
        {
            var createdLivro = await _livroInterface.CreateLivroAsync(livro);

            var retorno = new
            {
                mesagem = "Tudo certo",
                dadas = createdLivro,
                id = createdLivro.Id
            };

            return CreatedAtAction(nameof(GetLivroByIdAsync), new { id = createdLivro.Id }, retorno);
        }





        [HttpPut]
          public async Task<IActionResult> UpdateLivroAsync(Livro livro)
          {
              await _livroInterface.UpdateLivroAsync(livro);

              return NoContent();
          }

          [HttpDelete("{id}")]
           public async Task<IActionResult> DeleteLivroAsync(int id)
           {
                await _livroInterface.DeleteLivroAsync(id);

                return NoContent();
           }

    }
}