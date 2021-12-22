using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NETCoreWebApplication.Migrations
{
    public partial class addItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Steps_StepId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_Item_StepId",
                table: "Items",
                newName: "IX_Items_StepId");

            migrationBuilder.AlterColumn<int>(
                name: "StepId",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Steps_StepId",
                table: "Items",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Steps_StepId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_Items_StepId",
                table: "Item",
                newName: "IX_Item_StepId");

            migrationBuilder.AlterColumn<int>(
                name: "StepId",
                table: "Item",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Steps_StepId",
                table: "Item",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
