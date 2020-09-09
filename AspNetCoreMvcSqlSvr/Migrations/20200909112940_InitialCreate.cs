using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreMvcSqlSvr.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shohin",
                columns: table => new
                {
                    NumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShohinNum = table.Column<short>(type: "smallint", nullable: false),
                    ShohinName = table.Column<string>(type: "char(50)", maxLength: 50, nullable: true),
                    EditDate = table.Column<decimal>(type: "decimal(8, 0)", nullable: false),
                    EditTime = table.Column<decimal>(type: "numeric(6, 0)", nullable: false),
                    Note = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shohin", x => x.NumId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shohin");
        }
    }
}
