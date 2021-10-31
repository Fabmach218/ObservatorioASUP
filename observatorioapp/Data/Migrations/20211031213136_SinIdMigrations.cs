using Microsoft.EntityFrameworkCore.Migrations;

namespace observatorioapp.Data.Migrations
{
    public partial class SinIdMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_normativa_t_entidad_entidadId",
                table: "t_normativa");

            migrationBuilder.AlterColumn<string>(
                name: "nombrefile",
                table: "t_normativa",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "entidadId",
                table: "t_normativa",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_t_normativa_t_entidad_entidadId",
                table: "t_normativa",
                column: "entidadId",
                principalTable: "t_entidad",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_normativa_t_entidad_entidadId",
                table: "t_normativa");

            migrationBuilder.AlterColumn<string>(
                name: "nombrefile",
                table: "t_normativa",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "entidadId",
                table: "t_normativa",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_t_normativa_t_entidad_entidadId",
                table: "t_normativa",
                column: "entidadId",
                principalTable: "t_entidad",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
