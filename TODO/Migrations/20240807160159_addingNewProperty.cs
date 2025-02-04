using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODO.Migrations
{
    /// <inheritdoc />
    public partial class addingNewProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CategoriesId",
                table: "Tasks",
                column: "CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Categories_CategoriesId",
                table: "Tasks",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "CategoriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Categories_CategoriesId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CategoriesId",
                table: "Tasks");
        }
    }
}
