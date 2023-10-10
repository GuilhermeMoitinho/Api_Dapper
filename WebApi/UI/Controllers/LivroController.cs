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
            var response = new ServiceResponse<IEnumerable<Livro>>();

            try
            {
                var livros = await _livroInterface.GetAllLivrosAsync(skip, take);
                var count = await _livroInterface.CountLivrosInDatabase();
            
                double CountPages = count / take ; // Converte 'take' para double para divisão de ponto flutuante
                CountPages = Math.Ceiling(CountPages);

                if (response.Sucesso)
                {
                    response.Dados = livros.Dados; // Defina os dados da resposta com os livros
                    response.Mensagem = "Ocorreu um busca tranquila!";
                    response.Sucesso = true;
                    List<double> Paginacao = new List<double>();
                    Paginacao.Add(skip);
                    Paginacao.Add(take);
                    Paginacao.Add(CountPages);
                    Paginacao.Add(count);
                    response.Paginacao = Paginacao;
                }
                else
                {
                    response.Mensagem = "Ocorreu um erro ao contar os livros.";
                    response.Sucesso = false;
                }
            }
            catch (Exception x)
            {
                response.Mensagem = "Ocorreu um erro ao buscar os livros.";
                response.Sucesso = false;
            }

            return response;
        }




        [HttpGet("{id}")]
        public async Task<ServiceResponse<Livro>> GetLivroByIdAsync(int id)
        {
            var response = new ServiceResponse<Livro>();
            try
            {
                var livro = await _livroInterface.GetLivroByIdAsync(id);

               if(livro== null)
                        NotFound();

                response.Dados = livro.Dados;
                response.Mensagem = "ID encontrado com sucesso!";


            }catch(Exception x)
            {
                response.Mensagem = "Ocorreu um erro ao buscar os livros.";
                response.Sucesso = false;
            }
          

            return response;
        }

        [HttpPost]
          public async Task<ServiceResponse<IEnumerable<Livro>>> CreateLivroAsync(Livro livro)
          {
            var response = new ServiceResponse<IEnumerable<Livro>>();

            try
            {
                var ServiceResponseFuction = await _livroInterface.CreateLivroAsync(livro);

                if(ServiceResponseFuction == null)   
                {
                    response.Dados = null;
                    response.Mensagem = "Nao foi possivel fazer a criacao!";

                }

                response.Dados = ServiceResponseFuction.Dados; // Defina os dados da resposta com os livros
                response.Mensagem = $"Ocorreu um Criacao tranquila!";
                response.Sucesso = true;

            }catch(Exception x)
            {
                response.Dados = null;
                response.Mensagem = "Algo problema aconteceu!";
            }
            

            return response;

          }

        [HttpPut]
          public async Task<ServiceResponse<IEnumerable<Livro>>> UpdateLivroAsync(Livro livro)
          {
             var response = new ServiceResponse<IEnumerable<Livro>>();

            try
            {
                var ServiceResponseFuction = await _livroInterface.UpdateLivroAsync(livro);

                if(ServiceResponseFuction == null)   
                {
                    response.Dados = null;
                    response.Mensagem = "Nao foi possivel fazer a Edicao!";

                }

            

            response.Dados = ServiceResponseFuction.Dados;
            response.Mensagem = $"Ocorreu um atualizacao tranquila do Id {livro.Id}";
            response.Sucesso = true;
            }catch(Exception x)
            {
                response.Dados = null;
                response.Mensagem = "Algo problema aconteceu!";
            }
            

            return response;
          }

          [HttpDelete("{id}")]
           public async Task<ServiceResponse<IEnumerable<Livro>>> DeleteLivroAsync(int id)
           {
                var response = new ServiceResponse<IEnumerable<Livro>>();

            try
            {
                var ServiceResponseFuction = await _livroInterface.DeleteLivroAsync(id);

                if(ServiceResponseFuction == null)   
                {
                    response.Dados = null;
                    response.Mensagem = "Nao foi possivel fazer a Remocao!";

                }

            

            response.Dados = ServiceResponseFuction.Dados;
            response.Mensagem = $"Ocorreu um remocao tranquila do Id {id}!";
            response.Sucesso = true;
            }catch(Exception x)
            {
                response.Dados = null;
                response.Mensagem = "Algo problema aconteceu!";
            }
            

            return response;
           }

    }
}