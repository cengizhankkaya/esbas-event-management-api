using System;
using System.Xml;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration.UserSecrets;

#nullable disable

namespace esbas_internship_backendproject.Migrations
{
    public partial class AddStatusColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event_Type",
                columns: table => new
                {
                    T_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Type", x => x.T_ID);
                });

            migrationBuilder.CreateTable(
                name: "Event_Location",
                columns: table => new
                {
                    L_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Location", x => x.L_ID);
                });

            migrationBuilder.CreateTable(
                name: "User_Department",
                columns: table => new
                {
                    D_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Department", x => x.D_ID);
                });

            migrationBuilder.CreateTable(
                name: "User_IsOfficeEmployee",
                columns: table => new
                {
                    I_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_IsOfficeEmployee", x => x.I_ID);
                });

            migrationBuilder.CreateTable(
                name: "User_Gender",
                columns: table => new
                {
                    G_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Gender", x => x.G_ID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    EventDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Event_Status = table.Column<bool>(type: "bool", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {

                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardID = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsOfficeEmployee = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Events_Users",
                columns: table => new
                {
                    Events_UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: false),
                    CardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events_Users", x => x.Events_UserID);
                    table.ForeignKey(
                        name: "FK_Events_Users_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Users_Users_UserID",
                        column: x => x.CardID,
                        principalTable: "Users",
                        principalColumn: "CardID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_T_ID",
                table: "Events",
                column: "T_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_L_ID",
                table: "Events",
                column: "L_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_D_ID",
                table: "Users",
                column: "D_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_I_ID",
                table: "Users",
                column: "I_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_G_ID",
                table: "Users",
                column: "G_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Users_EventID",
                table: "Events_Users",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Users_UserID",
                table: "Users",
                column: "UserID");


            migrationBuilder.CreateIndex(
                name: "IX_Events_Users_ID",
                table: "Events_Users",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events_Users");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Event_Type");

            migrationBuilder.DropTable(
                name: "Event_Location");

            migrationBuilder.DropTable(
                name: "User_Department");

            migrationBuilder.DropTable(
                name: "User_IsOfficeEmployee");

            migrationBuilder.DropTable(
                name: "User_Gender");
        }
    }
}
