﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GestaoTarefasIPG.Models;

namespace GestaoTarefasIPG.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GestaoTarefasIPG.Models.Colaborador> Colaborador { get; set; }
        public DbSet<GestaoTarefasIPG.Models.Setor> Setor { get; set; }
        public DbSet<GestaoTarefasIPG.Models.Cargo> Cargo { get; set; }
    }
}
