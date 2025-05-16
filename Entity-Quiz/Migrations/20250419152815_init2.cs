using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_Quiz.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "TimeCapsules",
                newName: "StartedDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "TimeCapsules",
                newName: "EndedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndedDate",
                table: "Capsules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedDate",
                table: "Capsules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndedDate",
                table: "Capsules");

            migrationBuilder.DropColumn(
                name: "StartedDate",
                table: "Capsules");

            migrationBuilder.RenameColumn(
                name: "StartedDate",
                table: "TimeCapsules",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "EndedDate",
                table: "TimeCapsules",
                newName: "EndDate");
        }
    }
}
