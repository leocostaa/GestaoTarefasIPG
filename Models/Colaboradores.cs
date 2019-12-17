using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class Colaboradores
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        public int ColaboradoresId { get; set; }

        [Required]
        public string Profissao { get; set; }

        //[RegularExpression("^((0[1-9])|(1[0-9])|(2[0-9])|(3[0-1]))/((0[1-9])|(1[0-2]))/[0-9]{4}")]
        [Required]
        public int DataNascimento { get; set; }

        [EmailAddress]
        public string email { get; set; }
    }
}
