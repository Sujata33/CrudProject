using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudProject.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                 name: "sort_name",
                table: "Banks",
                type: "string",
                nullable: true,
                defaultValue: 0);
               
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                 name: "Sort_name",
                table: "Banks");
        }
    }
}
