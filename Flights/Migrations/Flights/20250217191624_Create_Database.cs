using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flights_Create_Book.Migrations.Flights
{
    /// <inheritdoc />
    public partial class Create_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "flights");

            migrationBuilder.CreateTable(
                name: "Flights",
                schema: "flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    airlineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fromLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    toLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fromDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    toDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fromTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    toTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passengerNumber = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights",
                schema: "flights");
        }
    }
}
