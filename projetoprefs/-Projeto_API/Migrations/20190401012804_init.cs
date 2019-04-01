using Microsoft.EntityFrameworkCore.Migrations;

namespace _Projeto_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Idade = table.Column<int>(nullable: false),
                    DataNascimento = table.Column<string>(nullable: true),
                    Funcao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "DataNascimento", "Funcao", "Idade", "Nome" },
                values: new object[] { 1, "20/06/1994", "Estagiária nível 1", 24, "Camila" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "DataNascimento", "Funcao", "Idade", "Nome" },
                values: new object[] { 2, "26/06/1996", "Estagiário nível 2", 22, "Gustavo" });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "DataNascimento", "Funcao", "Idade", "Nome" },
                values: new object[] { 3, "14/09/1991", "Estagiária nível 1", 28, "Livia" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
