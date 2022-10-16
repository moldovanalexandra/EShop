using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.Data.Migrations
{
    public partial class addprodusmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategorieProdus",
                table: "CategorieProdus");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "CategorieProdus");

            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "CategorieProdus",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategorieProdus",
                table: "CategorieProdus",
                column: "CategorieId");

            migrationBuilder.CreateTable(
                name: "Produs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Pret = table.Column<int>(nullable: false),
                    Stoc = table.Column<int>(nullable: false),
                    EsteDisponibil = table.Column<bool>(nullable: false),
                    CategorieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produs_CategorieProdus_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "CategorieProdus",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produs_CategorieId",
                table: "Produs",
                column: "CategorieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategorieProdus",
                table: "CategorieProdus");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "CategorieProdus");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CategorieProdus",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategorieProdus",
                table: "CategorieProdus",
                column: "Id");
        }
    }
}
