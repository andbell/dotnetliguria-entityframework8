using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetLiguria.EF8.Migrations
{
    /// <inheritdoc />
    public partial class DateInOrder3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingDate",
                table: "Orders",
                newName: "ShippingTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingTime",
                table: "Orders",
                newName: "ShippingDate");
        }
    }
}
