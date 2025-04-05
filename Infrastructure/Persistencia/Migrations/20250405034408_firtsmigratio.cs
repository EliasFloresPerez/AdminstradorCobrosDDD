using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class firtsmigratio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InformacionCobros",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Total = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ClienteId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacionCobros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformacionCobros_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InformacionCobros_ClienteId",
                table: "InformacionCobros",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformacionCobros");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
