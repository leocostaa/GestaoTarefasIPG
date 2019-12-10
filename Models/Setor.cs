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
        [StringLength(50, MinimumLength = 3)]
        public String Nome { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3)]
        public String Local { get; set; }
    }
}
