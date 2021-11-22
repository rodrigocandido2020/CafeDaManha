using Microsoft.EntityFrameworkCore.Migrations;

namespace CafeDaManha.Migrations
{
    public partial class Primeiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CadastroCafe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alimento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroCafe", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CadastroCafe");
        }
    }
}
