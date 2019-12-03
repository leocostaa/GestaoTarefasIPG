using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class Colaborador
    {

        public string Nome { get; set; }

        public int ColaboradorId { get; set; } //primary key

        public int Profissao { get; set; }

        public int DataNascimento { get; set; }

        [EmailAddress]
        public string email { get; set; }

    }
}
