using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertiesToUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2023, 11, 2, 11, 19, 28, 480, DateTimeKind.Local).AddTicks(4087), new DateTime(2023, 11, 2, 11, 19, 28, 480, DateTimeKind.Local).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2023, 11, 2, 11, 19, 28, 480, DateTimeKind.Local).AddTicks(4103), new DateTime(2023, 11, 2, 11, 19, 28, 480, DateTimeKind.Local).AddTicks(4104) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2023, 11, 2, 11, 19, 28, 480, DateTimeKind.Local).AddTicks(4106), new DateTime(2023, 11, 2, 11, 19, 28, 480, DateTimeKind.Local).AddTicks(4107) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2023, 11, 2, 11, 14, 23, 573, DateTimeKind.Local).AddTicks(3775), new DateTime(2023, 11, 2, 11, 14, 23, 573, DateTimeKind.Local).AddTicks(3786) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2023, 11, 2, 11, 14, 23, 573, DateTimeKind.Local).AddTicks(3789), new DateTime(2023, 11, 2, 11, 14, 23, 573, DateTimeKind.Local).AddTicks(3790) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created_Date", "Updated_Date" },
                values: new object[] { new DateTime(2023, 11, 2, 11, 14, 23, 573, DateTimeKind.Local).AddTicks(3792), new DateTime(2023, 11, 2, 11, 14, 23, 573, DateTimeKind.Local).AddTicks(3792) });
        }
    }
}
