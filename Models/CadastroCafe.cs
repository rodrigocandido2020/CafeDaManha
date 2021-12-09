using Microsoft.EntityFrameworkCore;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CafeDaManha.Models
{
    public class CadastroCafe
    {

        public int Id { get; set; }

        [StringLength(30, ErrorMessage = "{0} Minimo {2} caracteres é maximo {1} ." ,MinimumLength = 4)]
        [Required(ErrorMessage = "O campo {0} é Requirido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é Requirido")]
        public string Cpf { get; set; }


        [StringLength(30, ErrorMessage = "{0} Minimo {2} caracteres é maximo {1} .", MinimumLength = 4)]
        [Required(ErrorMessage = "O campo {0} é Requirido")]
        public string Alimento { get; set; }
    }
    
}
