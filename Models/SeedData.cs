using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefasIPG.Models
{
    public class SeedData
    {
        private const string ADMIN_ROLE = "admin";
        private const string FUNCIONARIO_ROLE = "func";

        public static void Populate(GestaoTarefasIPGDbContext db)
        {
            PopulateSetor(db);
            PopulateCargos(db);
            PopulateColaboradores(db);
        }


        public static async Task PopulateUsersAsync(UserManager<IdentityUser> userManager)
        {
            const string ADMIN_USERNAME = "admiiin@ipg.pt";
            const string ADMIN_PASSWORD = "Secret123$";

            const string FUNC_USERNAME = "colaborador1@ipg.pt";
            const string FUNC_PASSWORD = "Secret123$";

            IdentityUser user = await userManager.FindByNameAsync(ADMIN_USERNAME);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = ADMIN_USERNAME,
                    Email = ADMIN_USERNAME
                };

                await userManager.CreateAsync(user, ADMIN_PASSWORD);
            }

            if (!await userManager.IsInRoleAsync(user, ADMIN_ROLE))
            {
                await userManager.AddToRoleAsync(user, ADMIN_ROLE);
            }

            user = await userManager.FindByNameAsync(FUNC_USERNAME);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = FUNC_USERNAME,
                    Email = FUNC_USERNAME
                };

                await userManager.CreateAsync(user, FUNC_PASSWORD);
            }

            if (!await userManager.IsInRoleAsync(user, FUNCIONARIO_ROLE))
            {
                await userManager.AddToRoleAsync(user, FUNCIONARIO_ROLE);
            }

            user = await userManager.FindByNameAsync("test@ipg.pt");
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = "test@ipg.pt",
                    Email = "test@ipg.pt"
                };

                await userManager.CreateAsync(user, ADMIN_PASSWORD);
            }
        }


        public static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
        {

            if (!await roleManager.RoleExistsAsync(ADMIN_ROLE))
            {
                await roleManager.CreateAsync(new IdentityRole(ADMIN_ROLE));
            }

            if (!await roleManager.RoleExistsAsync(FUNCIONARIO_ROLE))
            {
                await roleManager.CreateAsync(new IdentityRole(FUNCIONARIO_ROLE));
            }
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
                new Colaboradores { Nome = "Leonardo Costa", Profissao = "Vice-Diretor", DataNascimento = 20091999, email = "leonardo@gmail.com" },
                new Colaboradores { Nome = "Hugo Amaral", Profissao = "Empregada de Limpezas", DataNascimento = 12111981, email = "amaral@gmail.com" },
                new Colaboradores { Nome = "Hugo Figueira", Profissao = "Rececionista", DataNascimento = 12121980, email = "hugo@gmail.com" },
                new Colaboradores { Nome = "Telmo Salvado", Profissao = "Diretor", DataNascimento = 15071996, email = "salvador@gmail.com" },
                new Colaboradores { Nome = "Manuel Proença", Profissao = "Secretariado", DataNascimento = 05081960, email = "mpmp@gmail.com" },
                new Colaboradores { Nome = "Odete Santos", Profissao = "Empregada de Limpeza", DataNascimento = 14021958, email = "oodete@gmail.com" },
                new Colaboradores { Nome = "Nigel Gomez", Profissao = "Professor", DataNascimento = 13021975, email = "gomez@gmail.com" }
                );
            db.SaveChanges();
        }
    }
}
