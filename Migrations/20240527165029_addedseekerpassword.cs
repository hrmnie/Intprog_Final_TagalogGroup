using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureSeekers.Migrations
{
    /// <inheritdoc />
    public partial class addedseekerpassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "seeker_password",
                table: "User_Seeker",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "seeker_password",
                table: "User_Seeker");
        }
    }
}
