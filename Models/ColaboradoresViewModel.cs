using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class ColaboradoresViewModel
    {
        public IEnumerable<Colaboradores> Colaboradores { get; set; }
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public int PrimeiraPagina { get; set; }
        public int UltimaPagina { get; set; }
        
    }
}
