using Microsoft.EntityFrameworkCore.Migrations;

namespace RRDL.Migrations
{
    public partial class AddedRevenueToRest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Revenue",
                table: "Restaurants",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Revenue",
                table: "Restaurants");
        }
    }
}
