using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogsFinaktiva.Infraestructure.Migrations
{
    public partial class eventlogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateRegisterByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateRegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateRegisterByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateRegisterDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventLogs");
        }
    }
}
