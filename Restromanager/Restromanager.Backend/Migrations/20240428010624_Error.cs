using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restromanager.Backend.Migrations
{
    /// <inheritdoc />
    public partial class Error : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Reports");

            migrationBuilder.AddColumn<int>(
                name: "UserReportId",
                table: "Reports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserReportId",
                table: "Reports",
                column: "UserReportId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReports_Name",
                table: "UserReports",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_UserReports_UserReportId",
                table: "Reports",
                column: "UserReportId",
                principalTable: "UserReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_UserReports_UserReportId",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "UserReports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_UserReportId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "UserReportId",
                table: "Reports");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
