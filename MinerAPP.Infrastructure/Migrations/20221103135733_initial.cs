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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cellphone", "ConfirmationCode", "Created", "CreatedBy", "Email", "Family", "IsActivated", "IsDeleted", "LastModified", "LastModifiedBy", "Name", "Points", "ProfileMediaURL", "Username", "WalletAddress" },
                values: new object[] { new Guid("2a365a02-6a9c-4ce7-81df-0ac4ce3aea27"), "00989394125130", null, null, null, "sina@yahoo.com", "Jouybari", false, false, null, null, "Sina", 0L, "uploads/2022/9/sina2.jpg", "sinful", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cellphone", "ConfirmationCode", "Created", "CreatedBy", "Email", "Family", "IsActivated", "IsDeleted", "LastModified", "LastModifiedBy", "Name", "Points", "ProfileMediaURL", "Username", "WalletAddress" },
                values: new object[] { new Guid("73b9f9d6-4d92-4007-99e4-85c466a11852"), "00989166666666", null, null, null, "sep@yahoo.com", "یاراحمدی", false, false, null, null, "سپیده", 0L, "uploads/2022/9/photo.jpg", "sepideh", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Cellphone", "ConfirmationCode", "Created", "CreatedBy", "Email", "Family", "IsActivated", "IsDeleted", "LastModified", "LastModifiedBy", "Name", "Points", "ProfileMediaURL", "Username", "WalletAddress" },
                values: new object[] { new Guid("bd104368-c8a3-4ede-bcc1-1777e97c614c"), "00989111769591", null, null, null, "vinona@yahoo.com", "پردلان", false, false, null, null, "محسن", 0L, "uploads/2022/9/99.jpg", "vinona", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
