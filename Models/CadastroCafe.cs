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

        [StringLength(30, MinimumLength = 4)]
        [Required]
        public string Nome { get; set; }

        [RegularExpression(@"^\d{3}\x2E\d{3}\x2E\d{3}\x2D\d{2}$")]
        [Required]
        public string Cpf { get; set; }


        [StringLength(30, ErrorMessage = "{0} teste {2} and {1}.", MinimumLength = 4)]
        [Required]        
        public string Alimento { get; set; }
    }
    
}
