using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace constraints.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ck_cars_size",
                table: "cars");

            migrationBuilder.AddCheckConstraint(
                name: "ck_cars_size",
                table: "cars",
                sql: "\"size\" in('Unknown', 'Compact', 'MidSize')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ck_cars_size",
                table: "cars");

            migrationBuilder.AddCheckConstraint(
                name: "ck_cars_size",
                table: "cars",
                sql: "\"size\" in('Unknown', 'Compact', 'MidSize', 'FullSize')");
        }
    }
}
