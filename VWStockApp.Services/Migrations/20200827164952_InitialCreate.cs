using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VWStockApp.Services.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bodies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    MakeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.MakeID);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeID = table.Column<int>(nullable: false),
                    BodyID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    YearModel = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CarModels_Bodies_BodyID",
                        column: x => x.BodyID,
                        principalTable: "Bodies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarModels_Makes_MakeID",
                        column: x => x.MakeID,
                        principalTable: "Makes",
                        principalColumn: "MakeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colours",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    CarModelID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colours", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Colours_CarModels_CarModelID",
                        column: x => x.CarModelID,
                        principalTable: "CarModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrimLevels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarModelID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrimLevels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TrimLevels_CarModels_CarModelID",
                        column: x => x.CarModelID,
                        principalTable: "CarModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrimLevelID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Features_TrimLevels_TrimLevelID",
                        column: x => x.TrimLevelID,
                        principalTable: "TrimLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockItem",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeID = table.Column<int>(nullable: true),
                    CarModelID = table.Column<int>(nullable: true),
                    TrimLevelID = table.Column<int>(nullable: true),
                    ColourID = table.Column<int>(nullable: true),
                    PriceModifier = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StockItem_CarModels_CarModelID",
                        column: x => x.CarModelID,
                        principalTable: "CarModels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockItem_Colours_ColourID",
                        column: x => x.ColourID,
                        principalTable: "Colours",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockItem_Makes_MakeID",
                        column: x => x.MakeID,
                        principalTable: "Makes",
                        principalColumn: "MakeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockItem_TrimLevels_TrimLevelID",
                        column: x => x.TrimLevelID,
                        principalTable: "TrimLevels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_BodyID",
                table: "CarModels",
                column: "BodyID");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_MakeID",
                table: "CarModels",
                column: "MakeID");

            migrationBuilder.CreateIndex(
                name: "IX_Colours_CarModelID",
                table: "Colours",
                column: "CarModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Features_TrimLevelID",
                table: "Features",
                column: "TrimLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_StockItem_CarModelID",
                table: "StockItem",
                column: "CarModelID");

            migrationBuilder.CreateIndex(
                name: "IX_StockItem_ColourID",
                table: "StockItem",
                column: "ColourID");

            migrationBuilder.CreateIndex(
                name: "IX_StockItem_MakeID",
                table: "StockItem",
                column: "MakeID");

            migrationBuilder.CreateIndex(
                name: "IX_StockItem_TrimLevelID",
                table: "StockItem",
                column: "TrimLevelID");

            migrationBuilder.CreateIndex(
                name: "IX_TrimLevels_CarModelID",
                table: "TrimLevels",
                column: "CarModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "StockItem");

            migrationBuilder.DropTable(
                name: "Colours");

            migrationBuilder.DropTable(
                name: "TrimLevels");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "Bodies");

            migrationBuilder.DropTable(
                name: "Makes");
        }
    }
}
