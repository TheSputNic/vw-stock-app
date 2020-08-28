using Microsoft.EntityFrameworkCore.Migrations;

namespace VWStockApp.Services.Migrations
{
    public partial class spGetStockById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure spGetStockById
                                @Id int
                                as
                                Begin
                                    Select* from StockItem
                                   where ID = @Id
                                End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetStockById";
            migrationBuilder.Sql(procedure);
        }
    }
}
