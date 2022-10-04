using System;
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cellphone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Points = table.Column<long>(type: "bigint", nullable: false),
                    ProfileMediaURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cellphone", "ConfirmationCode", "Created", "CreatedBy", "Family", "IsActivated", "LastModified", "LastModifiedBy", "Name", "Points", "ProfileMediaURL", "Username" },
                values: new object[] { new Guid("86ff82c4-a1fe-449c-a7d5-4704cf8444eb"), "09163681249", null, null, null, "یاراحمدی", false, null, null, "سپیده", 0L, "uploads/2022/9/photo.jpg", "sepideh" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cellphone", "ConfirmationCode", "Created", "CreatedBy", "Family", "IsActivated", "LastModified", "LastModifiedBy", "Name", "Points", "ProfileMediaURL", "Username" },
                values: new object[] { new Guid("8fe7656a-0c88-45db-895d-e2d262bbe4c1"), "09111769591", null, null, null, "پردلان", false, null, null, "محسن", 0L, "uploads/2022/9/99.jpg", "vinona" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cellphone", "ConfirmationCode", "Created", "CreatedBy", "Family", "IsActivated", "LastModified", "LastModifiedBy", "Name", "Points", "ProfileMediaURL", "Username" },
                values: new object[] { new Guid("a276ae1b-cf15-4318-ac35-985c58e40ed9"), "09394125130", null, null, null, "Jouybari", false, null, null, "Sina", 0L, "uploads/2022/9/sina2.jpg", "sinful" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
