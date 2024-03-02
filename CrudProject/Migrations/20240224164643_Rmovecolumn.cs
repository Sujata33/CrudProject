using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudProject.Migrations
{
    /// <inheritdoc />
    public partial class Rmovecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "full_name",
               table: "Banks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
