using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudProject.Migrations
{
    /// <inheritdoc />
    public partial class thirdmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "bank_id",
                table: "Branches",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Branches_bank_id",
                table: "Branches",
                column: "bank_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Banks_bank_id",
                table: "Branches",
                column: "bank_id",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Banks_bank_id",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_bank_id",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "bank_id",
                table: "Branches");
        }
    }
}
