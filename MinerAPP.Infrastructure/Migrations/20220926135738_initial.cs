using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinerAPP.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cellphone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Points = table.Column<long>(type: "bigint", nullable: false),
                    ProfileMediaURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Cellphone", "ConfirmationCode", "Family", "IsActivated", "Name", "Points", "ProfileMediaURL", "Username" },
                values: new object[] { 1, "09394125130", null, "Jouybari", false, "Sina", 0L, "uploads/2022/9/sina2.jpg", "sinful" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Cellphone", "ConfirmationCode", "Family", "IsActivated", "Name", "Points", "ProfileMediaURL", "Username" },
                values: new object[] { 2, "09111769591", null, "پردلان", false, "محسن", 0L, "uploads/2022/9/99.jpg", "vinona" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Cellphone", "ConfirmationCode", "Family", "IsActivated", "Name", "Points", "ProfileMediaURL", "Username" },
                values: new object[] { 3, "09163681249", null, "یاراحمدی", false, "سپیده", 0L, "uploads/2022/9/photo.jpg", "sepideh" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
