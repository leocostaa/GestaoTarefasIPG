﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class SetoresViewModel
    {
        public IEnumerable<Setor> Setores { get; set; }
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public int PrimeiraPagina { get; set; }
        public int UltimaPagina { get; set; }
    }
}
