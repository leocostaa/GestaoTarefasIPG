using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class SeedData
    {
        public static void Populate(GestaoTarefasIPGDbContext db)
        {
            PopulateSetor(db);
            PopulateCargos(db);
            PopulateColaboradores(db);
        }

        private static void PopulateSetor(GestaoTarefasIPGDbContext db)
        {
            if (db.Setor.Any()) return;

            db.Setor.AddRange(
                new Setor { Nome = "Cantina 1", Local = "Serviços Centrais" },
                new Setor { Nome = "Cantina 2", Local = "Residências" },
                new Setor { Nome = "Erasmus", Local = "Serviços Centrais" },
                new Setor { Nome = "Bar", Local = "ESTG" },
                new Setor { Nome = "Direção", Local = "ESTG" },
                new Setor { Nome = "Secretaria", Local = "Serviços Centrais" },
                new Setor { Nome = "Laboratório de Física", Local = "ESTG" }
                );
            db.SaveChanges();
        }

        private static void PopulateCargos(GestaoTarefasIPGDbContext db)
        {
            if (db.Cargos.Any()) return;

            db.Cargos.AddRange(
                new Cargos { Nome = "Empregada de Limpeza", Superior = "Diretor" },
                new Cargos { Nome = "Professor", Superior = "Diretor" },
                new Cargos { Nome = "Secretariado", Superior = "Vice-Director" },
                new Cargos { Nome = "Tesoureiro", Superior = "Departamento de contas" },
                new Cargos { Nome = "Vice-Diretor", Superior = "Diretor" },
                new Cargos { Nome = "Diretor", Superior = "Estado" },
                new Cargos { Nome = "Rececionista", Superior = "Vice-Diretor" }
                );
            db.SaveChanges();
        }

        private static void PopulateColaboradores(GestaoTarefasIPGDbContext db)
        {
            if (db.Colaboradores.Any()) return;

            db.Colaboradores.AddRange(
                new Colaboradores { Nome = "Leonardo Costa", Profissao = "Vice-Diretor", DataNascimento = 01/08/2008, email = "leonardo@gmail.com" },
                new Colaboradores { Nome = "Hugo Amaral", Profissao = "Empregada de Limpezas", DataNascimento = 02/02/95, email = "amaral@gmail.com" },
                new Colaboradores { Nome = "Hugo Figueira", Profissao = "Rececionista", DataNascimento = 03/05/1975, email = "hugo@gmail.com" },
                new Colaboradores { Nome = "Telmo Salvado", Profissao = "Diretor", DataNascimento = 04/01/1960, email = "salvador@gmail.com" }
                );
            db.SaveChanges();
        }
    }
}
