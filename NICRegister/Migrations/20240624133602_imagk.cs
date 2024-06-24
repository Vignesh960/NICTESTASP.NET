﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NICRegister.Migrations
{
    /// <inheritdoc />
    public partial class imagk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "MyRegistrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "MyRegistrations");
        }
    }
}
