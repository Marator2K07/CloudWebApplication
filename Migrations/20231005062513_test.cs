using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CloudWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_zooRegistration",
                table: "zooRegistration");

            migrationBuilder.RenameTable(
                name: "zooRegistration",
                newName: "ZooRegistrations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ZooRegistrations",
                table: "ZooRegistrations",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ZooRegistrations",
                table: "ZooRegistrations");

            migrationBuilder.RenameTable(
                name: "ZooRegistrations",
                newName: "zooRegistration");

            migrationBuilder.AddPrimaryKey(
                name: "PK_zooRegistration",
                table: "zooRegistration",
                column: "Id");
        }
    }
}
