using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloriculturaFlores.Migrations
{
    public partial class PopularCategoris : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERt INTO Categorias(Categorianome, Descricao) VALUES ('Simples','feito com flores de epoca')");
            migrationBuilder.Sql("INSERt INTO Categorias(Categorianome, Descricao) VALUES ('Luxo','feito com flores de nobre')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
