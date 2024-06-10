using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Realtor.API.Migrations
{
    /// <inheritdoc />
    public partial class RenamePropertyUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertUnits",
                table: "PropertUnits");

            migrationBuilder.RenameTable(
                name: "PropertUnits",
                newName: "PropertyUnits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyUnits",
                table: "PropertyUnits",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyUnits",
                table: "PropertyUnits");

            migrationBuilder.RenameTable(
                name: "PropertyUnits",
                newName: "PropertUnits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertUnits",
                table: "PropertUnits",
                column: "Id");
        }
    }
}
