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
        public int ColaboradorId { get; set; }

        [Required]
        public string Profissao { get; set; }

        [RegularExpression("\d[1 - 31])(-\d[1 - 12])(-\d[1900 - 2050]")]
        public int DataNascimento { get; set; }

        [EmailAddress]
        public string email { get; set; }
    }
}
