using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class Setor
    {
        [Required]
        public int SetorId { get; set; }
        [Required]
        public String Nome { get; set; }
        [Required]
        public String Local { get; set; }
    }
}
