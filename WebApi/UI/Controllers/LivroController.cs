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
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface LivroInterface)
        {
            _livroInterface = LivroInterface;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetAllLivros()
        {
            var livros = await _livroInterface.GetAllLivros();

            if(!livros.Any())
            {
                return NotFound("Nenhum registro localizado!");
            }

            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivroById(int id)
        {
            var livro = await _livroInterface.GetLivroById(id);

            if(livro == null)
            {
                return NotFound("Nenhum de Id foi localizado!");
            }

            return Ok(livro);
        }

        [HttpPost]
          public async Task<ActionResult<IEnumerable<Livro>>> CreateLivro(Livro livro)
          {
            var Livro = await _livroInterface.CreateLivro(livro);

            if(Livro == null)   
            {
                return NotFound("Nenhum argumento foi colocado!");
            }

            return Ok(Livro);

          }

        [HttpPut]
          public async Task<ActionResult<IEnumerable<Livro>>> UpdateLivro(Livro livro)
          {
             var Registro = await _livroInterface.GetLivroById(livro.Id);

            if(Registro == null)   
            {
                return NotFound("Nenhum de Id foi localizado!");
            }

            var LivroBanco = await _livroInterface.UpdateLivro(livro);

            return Ok(LivroBanco);
          }

          [HttpDelete("{Id}")]
           public async Task<ActionResult<IEnumerable<Livro>>> DeleteLivro(int Id)
           {
                var Registro = await _livroInterface.GetLivroById(Id);

                if(Registro == null)   
                {
                    return NotFound("Nenhum de Id foi localizado!");
                }

                var LivroBanco = await _livroInterface.DeleteLivro(Id);

                return Ok(LivroBanco);
           }

    }
}