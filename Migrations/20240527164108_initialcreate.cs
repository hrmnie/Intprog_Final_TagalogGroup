using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureSeekers.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_Seeker",
                columns: table => new
                {
                    seeker_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    seeker_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    seeker_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seeker_contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seeker_address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Seeker", x => x.seeker_id);
                });

            migrationBuilder.CreateTable(
                name: "User_Post",
                columns: table => new
                {
                    post_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    seeker_id = table.Column<int>(type: "int", nullable: false),
                    post_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    post_caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    post_location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Post", x => x.post_id);
                    table.ForeignKey(
                        name: "FK_User_Post_User_Seeker_seeker_id",
                        column: x => x.seeker_id,
                        principalTable: "User_Seeker",
                        principalColumn: "seeker_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Post_seeker_id",
                table: "User_Post",
                column: "seeker_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Post");

            migrationBuilder.DropTable(
                name: "User_Seeker");
        }
    }
}
