using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainningSystem.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "MangerName", "Name" },
                values: new object[,]
                {
                    { 1, "Alaa", "SD" },
                    { 2, "Asmaa", "OS" }
                });

            migrationBuilder.InsertData(
                table: "instructors",
                columns: new[] { "Id", "CourseId", "DepartmentId", "Imag", "Name", "address", "salary" },
                values: new object[,]
                {
                    { 1, null, 1, "m.jpg", "Ahmed", "cairo", 1000m },
                    { 2, null, 2, "m2.jpg", "Muhammed", "Menofia", 2000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
