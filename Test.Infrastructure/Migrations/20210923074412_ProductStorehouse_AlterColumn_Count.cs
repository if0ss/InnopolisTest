using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Infrastructure.Migrations
{
    public partial class ProductStorehouse_AlterColumn_Count : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "ProductStorehouses",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Count",
                table: "ProductStorehouses",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
