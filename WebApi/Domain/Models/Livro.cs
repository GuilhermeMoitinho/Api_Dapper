using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Dados necessarios! Insira seu Titulo!")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Dados necessarios! Insira seu Autor!")]
        public string Autor { get; set; } = string.Empty;
    }
}