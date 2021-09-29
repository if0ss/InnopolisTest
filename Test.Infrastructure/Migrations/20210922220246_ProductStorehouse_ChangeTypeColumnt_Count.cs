using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Infrastructure.Migrations
{
    public partial class ProductStorehouse_ChangeTypeColumnt_Count : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Count",
                table: "ProductStorehouses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Count",
                table: "ProductStorehouses",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
