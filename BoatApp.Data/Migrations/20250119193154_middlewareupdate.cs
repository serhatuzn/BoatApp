using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoatApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class middlewareupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 19, 31, 54, 408, DateTimeKind.Utc).AddTicks(4357));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 22, 27, 32, 900, DateTimeKind.Utc).AddTicks(3805));
        }
    }
}
