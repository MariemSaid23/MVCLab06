using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainningSystem.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "salary",
                value: 9000000m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "instructors",
                keyColumn: "Id",
                keyValue: 1,
                column: "salary",
                value: 1000m);
        }
    }
}
