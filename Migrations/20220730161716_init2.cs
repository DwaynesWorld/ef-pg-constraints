using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace constraints.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ck_cars_body",
                table: "cars");

            migrationBuilder.AddCheckConstraint(
                name: "ck_cars_body",
                table: "cars",
                sql: "body in('Unknown', 'Coupe', 'Sedan', 'Wagon', 'SUV', 'Truck', 'Van', 'Semi')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ck_cars_body",
                table: "cars");

            migrationBuilder.AddCheckConstraint(
                name: "ck_cars_body",
                table: "cars",
                sql: "body in('Unknown', 'Coupe', 'Sedan', 'Wagon', 'SUV', 'Truck', 'Van')");
        }
    }
}
