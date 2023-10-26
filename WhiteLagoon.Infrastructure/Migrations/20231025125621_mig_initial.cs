using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Sqft = table.Column<int>(type: "int", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Created_Date", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Sqft", "Updated_Date" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 25, 15, 56, 21, 643, DateTimeKind.Local).AddTicks(469), "Bu lüks deniz villası, harika bir manzaraya sahiptir ve 8 kişiye kadar konaklama imkanı sunar.", "https://example.com/villa1.jpg", "Lüks Deniz Villası", 8, 500.0, 3000, new DateTime(2023, 10, 25, 15, 56, 21, 643, DateTimeKind.Local).AddTicks(487) },
                    { 2, new DateTime(2023, 10, 25, 15, 56, 21, 643, DateTimeKind.Local).AddTicks(491), "Ormanın huzurlu atmosferinde bulunan bu villa, doğa severler için mükemmel bir seçenektir.", "https://example.com/villa2.jpg", "Orman Kenarı Villa", 6, 400.0, 2500, new DateTime(2023, 10, 25, 15, 56, 21, 643, DateTimeKind.Local).AddTicks(492) },
                    { 3, new DateTime(2023, 10, 25, 15, 56, 21, 643, DateTimeKind.Local).AddTicks(493), "Şehir merkezinde yer alan bu stüdyo daire, iş seyahati yapanlar için idealdir.", "https://example.com/villa3.jpg", "Şehir Merkezi Stüdyo Dairesi", 2, 100.0, 800, new DateTime(2023, 10, 25, 15, 56, 21, 643, DateTimeKind.Local).AddTicks(494) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
