using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviezzzzApp.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GrageName",
                table: "Grade",
                newName: "GradeName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GradeName",
                table: "Grade",
                newName: "GrageName");
        }
    }
}
