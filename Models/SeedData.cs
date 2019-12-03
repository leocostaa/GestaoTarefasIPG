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
    }
}
