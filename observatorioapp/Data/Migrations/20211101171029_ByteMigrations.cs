using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace observatorioapp.Data.Migrations
{
    public partial class ByteMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "archivo",
                table: "t_normativa",
                type: "bytea",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "archivo",
                table: "t_normativa");
        }
    }
}
