using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureSeekers.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "seeker_image",
                table: "User_Seeker");

            migrationBuilder.AlterColumn<string>(
                name: "seeker_name",
                table: "User_Seeker",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "seeker_name",
                table: "User_Seeker",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "seeker_image",
                table: "User_Seeker",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
