using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WordMaster.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    WordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.WordId);
                });

            migrationBuilder.InsertData(
                table: "Words",
                columns: new[] { "WordId", "Value" },
                values: new object[,]
                {
                    { 1, "count" },
                    { 2, "flush" },
                    { 3, "eerie" },
                    { 4, "fault" },
                    { 5, "blast" },
                    { 6, "trick" },
                    { 7, "scare" },
                    { 8, "folly" },
                    { 9, "steam" },
                    { 10, "quark" },
                    { 11, "field" },
                    { 12, "house" },
                    { 13, "cloth" },
                    { 14, "realm" },
                    { 15, "weird" },
                    { 16, "noise" },
                    { 17, "crumb" },
                    { 18, "clank" },
                    { 19, "night" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
