using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.Data.Migrations
{
    public partial class addComandaDetaliiComanda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Pret",
                table: "Produs",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3, 2)");

            migrationBuilder.CreateTable(
                name: "Comenzi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: false),
                    NrComanda = table.Column<string>(nullable: true),
                    NrTelefon = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: false),
                    DataComanda = table.Column<System.DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comenzi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetaliiComenzi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComandaId = table.Column<int>(nullable: false),
                    ProdusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetaliiComenzi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetaliiComenzi_Comenzi_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comenzi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetaliiComenzi_Produs_ProdusId",
                        column: x => x.ProdusId,
                        principalTable: "Produs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetaliiComenzi_ComandaId",
                table: "DetaliiComenzi",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetaliiComenzi_ProdusId",
                table: "DetaliiComenzi",
                column: "ProdusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetaliiComenzi");

            migrationBuilder.DropTable(
                name: "Comenzi");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Produs",
                type: "decimal(3, 2)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
