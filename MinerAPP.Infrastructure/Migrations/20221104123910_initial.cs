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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WalletAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersLogins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IMEI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLogins", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cellphone", "ConfirmationCode", "Created", "CreatedBy", "Email", "Family", "IsActivated", "IsDeleted", "LastModified", "LastModifiedBy", "Name", "Points", "ProfileMediaURL", "Username", "WalletAddress" },
                values: new object[] { new Guid("7dbfe599-0cbd-45ea-8e9b-e11370f3b4d0"), "00989394125130", null, null, null, "sina@yahoo.com", "Jouybari", false, false, null, null, "Sina", 0L, "uploads/2022/9/sina2.jpg", "sinful", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cellphone", "ConfirmationCode", "Created", "CreatedBy", "Email", "Family", "IsActivated", "IsDeleted", "LastModified", "LastModifiedBy", "Name", "Points", "ProfileMediaURL", "Username", "WalletAddress" },
                values: new object[] { new Guid("9ed89181-426b-48a1-ae7d-e0129dc20e30"), "00989111769591", null, null, null, "vinona@yahoo.com", "پردلان", false, false, null, null, "محسن", 0L, "uploads/2022/9/99.jpg", "vinona", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cellphone", "ConfirmationCode", "Created", "CreatedBy", "Email", "Family", "IsActivated", "IsDeleted", "LastModified", "LastModifiedBy", "Name", "Points", "ProfileMediaURL", "Username", "WalletAddress" },
                values: new object[] { new Guid("f2b9d695-3fc6-43b5-b1a7-ead166311376"), "00989166666666", null, null, null, "sep@yahoo.com", "یاراحمدی", false, false, null, null, "سپیده", 0L, "uploads/2022/9/photo.jpg", "sepideh", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UsersLogins");
        }
    }
}
