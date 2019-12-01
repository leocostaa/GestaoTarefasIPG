using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefasIPG.Data.Migrations
{
    public partial class Colaborador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaborador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    ColaboradorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataNascimento = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profissao = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.ColaboradorId);
                });
        }
    }
}
