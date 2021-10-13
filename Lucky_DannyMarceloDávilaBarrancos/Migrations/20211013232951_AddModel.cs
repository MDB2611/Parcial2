using Microsoft.EntityFrameworkCore.Migrations;

namespace Lucky_DannyMarceloDávilaBarrancos.Migrations
{
    public partial class AddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lucky",
                columns: table => new
                {
                    SuerteID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lucky", x => x.SuerteID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lucky");
        }
    }
}
