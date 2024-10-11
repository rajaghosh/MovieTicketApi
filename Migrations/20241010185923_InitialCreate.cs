using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieTicketApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RunningMin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheatreMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheatreMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheatreScreen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheatreId = table.Column<int>(type: "int", nullable: false),
                    ScreenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rows = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatNos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheatreScreen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheatreScreen_TheatreMaster_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "TheatreMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoneBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ScreenId = table.Column<int>(type: "int", nullable: false),
                    Row = table.Column<int>(type: "int", nullable: false),
                    SeatNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_MovieMaster_MovieId",
                        column: x => x.MovieId,
                        principalTable: "MovieMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_TheatreScreen_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "TheatreScreen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_UserMaster_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovieListing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ScreenId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieListing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieListing_MovieMaster_MovieId",
                        column: x => x.MovieId,
                        principalTable: "MovieMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieListing_TheatreScreen_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "TheatreScreen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MovieMaster",
                columns: new[] { "Id", "Description", "Language", "Name", "RunningMin" },
                values: new object[,]
                {
                    { 1, "Action Movie", "Hindi", "Godzilla", 120 },
                    { 2, "Horror Movie", "Hindi", "Stree2", 120 },
                    { 3, "Action Movie", "Hindi", "Joker", 120 }
                });

            migrationBuilder.InsertData(
                table: "TheatreMaster",
                columns: new[] { "Id", "Description", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Multiplex", "Kolkata", "Inox-Kolkata" },
                    { 2, "Multiplex", "Kolkata", "PVR-Kolkata" },
                    { 3, "Multiplex", "NCR", "Inox-NCR" },
                    { 4, "Multiplex", "NCR", "PVR-NCR" }
                });

            migrationBuilder.InsertData(
                table: "UserMaster",
                columns: new[] { "Id", "Email", "Location", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "a1@deloitte.com", "kolkata", "a1", "abc1@123" },
                    { 2, "a2@deloitte.com", "Hyderabad", "a2", "abc2@123" },
                    { 3, "a3@deloitte.com", "Pune", "a3", "abc3@123" },
                    { 4, "a4@deloitte.com", "NCR", "a4", "abc4@123" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MovieId",
                table: "Booking",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ScreenId",
                table: "Booking",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieListing_MovieId",
                table: "MovieListing",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieListing_ScreenId",
                table: "MovieListing",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_TheatreScreen_TheatreId",
                table: "TheatreScreen",
                column: "TheatreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "MovieListing");

            migrationBuilder.DropTable(
                name: "UserMaster");

            migrationBuilder.DropTable(
                name: "MovieMaster");

            migrationBuilder.DropTable(
                name: "TheatreScreen");

            migrationBuilder.DropTable(
                name: "TheatreMaster");
        }
    }
}
