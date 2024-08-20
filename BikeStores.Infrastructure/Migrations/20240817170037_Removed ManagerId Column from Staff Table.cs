using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeStores.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedManagerIdColumnfromStaffTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Staffs_ManagerId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_ManagerId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Staffs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Staffs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_ManagerId",
                table: "Staffs",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Staffs_ManagerId",
                table: "Staffs",
                column: "ManagerId",
                principalTable: "Staffs",
                principalColumn: "StaffId");
        }
    }
}
