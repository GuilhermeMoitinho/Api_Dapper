using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Domain.Models.Service
{
   public class ServiceResponse<T>
    {   
        public List<double> Paginacao {get; set;}
        public T? Dados { get; set; }
   
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;
    }
}