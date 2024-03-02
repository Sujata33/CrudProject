using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudProject.Migrations
{
    /// <inheritdoc />
    public partial class SUREHOBE11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "full_name",
                table: "Banks",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "full_name",
                table: "Banks");
        }
    }
}
