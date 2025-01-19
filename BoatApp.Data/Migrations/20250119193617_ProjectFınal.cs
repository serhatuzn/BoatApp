﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoatApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProjectFınal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 19, 36, 17, 656, DateTimeKind.Utc).AddTicks(1356));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 19, 19, 34, 23, 102, DateTimeKind.Utc).AddTicks(5234));
        }
    }
}
