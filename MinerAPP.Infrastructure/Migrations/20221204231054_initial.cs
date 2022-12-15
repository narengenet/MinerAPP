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
                name: "StaticDictionaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticDictionaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    TheHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheWallet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsDeposit = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

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
                    Balance = table.Column<double>(type: "float", nullable: false),
                    ProfileMediaURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WalletAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inviter = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                table: "StaticDictionaries",
                columns: new[] { "Id", "Created", "CreatedBy", "IsDeleted", "LastModified", "LastModifiedBy", "TheName", "TheValue" },
                values: new object[,]
                {
                    { new Guid("0b46cd67-d90c-4942-bb2c-49c65fcb8ccd"), null, null, false, null, null, "deposithelp", "Deposit Helpppppppppppppppppp" },
                    { new Guid("2cccba59-d810-4851-980f-fb11fed326b2"), null, null, false, null, null, "accounthelp", "Account Helpppppppppppppppppp" },
                    { new Guid("4256d06b-8fce-4dd7-992d-5fe129ea2478"), null, null, false, null, null, "inviterreward", "0.1" },
                    { new Guid("ad1e5744-b267-420b-b680-c19bad74ef30"), null, null, false, null, null, "thewallet", "TJ1000000000000000000000000000000" },
                    { new Guid("cb2136e7-aa62-458a-8315-a34134c9ffd9"), null, null, false, null, null, "theqr", "https://localhost:7249/images/sina.jpg" },
                    { new Guid("cdecaac4-fc52-43ff-a64b-b9ce2ca7778f"), null, null, false, null, null, "withdrawhelp", "Withdraw Helpppppppppppppppppp" },
                    { new Guid("e487d40b-3ccd-48d8-af00-eafbbf30060a"), null, null, false, null, null, "transactionhelp", "Transaction Helpppppppppppppppppp" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Balance", "Cellphone", "ConfirmationCode", "Created", "CreatedBy", "Email", "Family", "Inviter", "IsActivated", "IsDeleted", "LastModified", "LastModifiedBy", "Name", "ProfileMediaURL", "Username", "WalletAddress" },
                values: new object[] { new Guid("84020544-b6ce-4c4f-9a4f-d583484ba67e"), 0.0, "00989394125130", null, null, null, "sarparast_r@yahoo.com", "Jouybari", null, false, false, null, null, "Sina", "uploads/2022/9/sina2.jpg", "sinful", "TJ12333333333333323333333333333333" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaticDictionaries");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UsersLogins");
        }
    }
}
