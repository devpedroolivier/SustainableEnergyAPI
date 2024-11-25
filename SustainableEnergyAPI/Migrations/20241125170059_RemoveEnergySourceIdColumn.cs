using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SustainableEnergyAPI.Migrations
{
    public partial class RemoveEnergySourceIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EnergyResources",
                table: "EnergyResources");

            migrationBuilder.RenameTable(
                name: "EnergyResources",
                newName: "EnergyResource");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnergyResource",
                table: "EnergyResource",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EnergyResource",
                table: "EnergyResource");

            migrationBuilder.RenameTable(
                name: "EnergyResource",
                newName: "EnergyResources");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnergyResources",
                table: "EnergyResources",
                column: "Id");
        }
    }
}
