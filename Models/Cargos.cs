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
        [StringLength (20, MinimumLength = 3)]  
        public string Nome { get; set; }
        
        [Required]
        [StringLength (20, MinimumLength = 3)]  
        public string Superior { get; set; }


    }
}
