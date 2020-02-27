using Microsoft.EntityFrameworkCore.Migrations;

namespace nadya_asp_rest_test1.Migrations
{
    public partial class AddOrderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Orders_Orderid",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "OrderDetails");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_Orderid",
                table: "OrderDetails",
                newName: "IX_OrderDetails_Orderid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_Orderid",
                table: "OrderDetails",
                column: "Orderid",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_Orderid",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderDetail");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_Orderid",
                table: "OrderDetail",
                newName: "IX_OrderDetail_Orderid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Orders_Orderid",
                table: "OrderDetail",
                column: "Orderid",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
