using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Passsword = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Freight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Thuc an" },
                    { 2, "vong co" },
                    { 3, "do choi" },
                    { 4, "quan ao" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "City", "CompanyName", "Country", "Email", "Passsword" },
                values: new object[,]
                {
                    { 1, "Ha Noi", "FSoft", "Vietnam", "test1@gmail.com", "123456" },
                    { 2, "Hue", "FA", "Vietnam", "test2@gmail.com", "123456" },
                    { 3, "Da nang", "TPBank", "Vietnam", "test3@gmail.com", "123456" },
                    { 4, "HCM", "VPBank", "Vietnam", "test4@gmail.com", "123456" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Freight", "MemberId", "OrderDate", "RequiredDate", "ShippedDate" },
                values: new object[,]
                {
                    { 1, 50000m, 1, new DateTime(2025, 2, 11, 1, 25, 28, 328, DateTimeKind.Local).AddTicks(2470), new DateTime(2025, 2, 16, 1, 25, 28, 328, DateTimeKind.Local).AddTicks(2478), new DateTime(2025, 2, 13, 1, 25, 28, 328, DateTimeKind.Local).AddTicks(2483) },
                    { 2, 45000m, 2, new DateTime(2025, 2, 11, 1, 25, 28, 328, DateTimeKind.Local).AddTicks(2484), new DateTime(2025, 2, 15, 1, 25, 28, 328, DateTimeKind.Local).AddTicks(2485), new DateTime(2025, 2, 12, 1, 25, 28, 328, DateTimeKind.Local).AddTicks(2485) },
                    { 3, 55000m, 3, new DateTime(2025, 2, 11, 1, 25, 28, 328, DateTimeKind.Local).AddTicks(2486), new DateTime(2025, 2, 17, 1, 25, 28, 328, DateTimeKind.Local).AddTicks(2486), new DateTime(2025, 2, 14, 1, 25, 28, 328, DateTimeKind.Local).AddTicks(2487) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductName", "UnitInStock", "UnitPrice", "Weight" },
                values: new object[,]
                {
                    { 1, 1, "Thức ăn cho chó", 50, 150000m, 2.5m },
                    { 2, 2, "Vòng cổ thông minh", 30, 300000m, 0.2m },
                    { 3, 3, "Bóng đồ chơi", 40, 100000m, 0.5m },
                    { 4, 4, "Áo cho chó", 20, 200000m, 0.3m }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderId", "ProductId", "Discount", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 0m, 2, 150000m },
                    { 1, 2, 10m, 1, 300000m },
                    { 2, 3, 5m, 3, 100000m },
                    { 3, 1, 0m, 1, 150000m },
                    { 3, 4, 0m, 1, 200000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MemberId",
                table: "Orders",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
