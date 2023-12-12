using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class editsalttype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Auth");
            migrationBuilder.AddColumn<byte[]>(
                name: "Salt",
                table: "Auth",
                type: "varbinary(max)",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Auth");
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Auth",
                type: "nvarchar(max)",
                nullable: false);
        }
    }
}
