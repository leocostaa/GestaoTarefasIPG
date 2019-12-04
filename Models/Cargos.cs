using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class Cargos
    {
        [Required]
        public int CargosId { get; set; }
        
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string Superior { get; set; }


    }
}
