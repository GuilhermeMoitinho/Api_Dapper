using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<Livro>>> GetAllLivrosAsync(int skip = 0, int take = 15)
        {
            var livros = await _livroInterface.GetAllLivrosAsync(skip, take);

            return Ok(livros);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivroByIdAsync(int id)
        {
            var livro = await _livroInterface.GetLivroByIdAsync(id);

            if(livro == null)
            {
                return NotFound("Nenhum de Id foi localizado!");
            }

            return Ok(livro);
        }

        [HttpPost]
          public async Task<ActionResult<IEnumerable<Livro>>> CreateLivroAsync(Livro livro)
          {
            var Livro = await _livroInterface.CreateLivroAsync(livro);

            if(Livro == null)   
            {
                return NotFound("Nenhum argumento foi colocado!");
            }

            return Ok(Livro);

          }

        [HttpPut]
          public async Task<ActionResult<IEnumerable<Livro>>> UpdateLivroAsync(Livro livro)
          {
             var Registro = await _livroInterface.GetLivroByIdAsync(livro.Id);

            if(Registro == null)   
            {
                return NotFound("Nenhum de Id foi localizado!");
            }

            var LivroBanco = await _livroInterface.UpdateLivroAsync(livro);

            return Ok(LivroBanco);
          }

          [HttpDelete("{id}")]
           public async Task<ActionResult<IEnumerable<Livro>>> DeleteLivroAsync(int id)
           {
                var Registro = await _livroInterface.GetLivroByIdAsync(id);

                if(Registro == null)   
                {
                    return NotFound("Nenhum de Id foi localizado!");
                }

                var LivroBanco = await _livroInterface.DeleteLivroAsync(id);

                return Ok(LivroBanco);
           }

    }
}