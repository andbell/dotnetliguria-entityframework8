using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetLiguria.EF8.Migrations
{
    /// <inheritdoc />
    public partial class DateInOrder2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeOnly>(
                name: "ShippingDate",
                table: "Orders",
                type: "time",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingDate",
                table: "Orders");
        }
    }
}
