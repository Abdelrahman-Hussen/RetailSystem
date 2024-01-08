using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RetailSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Branches_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cashier",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cashier", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cashier_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceHeader",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Invoicedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CashierID = table.Column<int>(type: "int", nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceHeader", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceHeader_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceHeader_Cashier_CashierID",
                        column: x => x.CashierID,
                        principalTable: "Cashier",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemCount = table.Column<float>(type: "real", nullable: false),
                    ItemPrice = table.Column<float>(type: "real", nullable: false),
                    InvoiceHeaderID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_InvoiceHeader_InvoiceHeaderID",
                        column: x => x.InvoiceHeaderID,
                        principalTable: "InvoiceHeader",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CityName" },
                values: new object[,]
                {
                    { 1, "القاهرة - مدينة نصر" },
                    { 2, "القاهرة - القاهرة الجديدة" },
                    { 3, "القاهرة - الشروق" },
                    { 4, "القاهرة - العبور" },
                    { 5, "الاسكندرية - سموحة" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "ID", "BranchName", "CityID" },
                values: new object[,]
                {
                    { 2, "فرع الحي السابع", 1 },
                    { 3, "فرع عباس العقاد", 1 },
                    { 4, "فرع التجمع الاول", 2 },
                    { 5, "فرع سموحه", 5 },
                    { 6, "فرع الشروق", 3 },
                    { 7, "فرع العبور", 4 }
                });

            migrationBuilder.InsertData(
                table: "Cashier",
                columns: new[] { "ID", "BranchID", "CashierName" },
                values: new object[,]
                {
                    { 1, 2, "محمد احمد" },
                    { 2, 3, "محمود احمد محمد" },
                    { 3, 2, "مصطفي عبد السميع" },
                    { 4, 6, "احمد عبد الرحمن" },
                    { 5, 4, "ساره عبد الله" }
                });

            migrationBuilder.InsertData(
                table: "InvoiceHeader",
                columns: new[] { "ID", "BranchID", "CashierID", "CustomerName", "Invoicedate" },
                values: new object[,]
                {
                    { 2L, 2, 1, "محمد عبد الله", new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, 3, 2, "محمود احمد", new DateTime(2022, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "ID", "InvoiceHeaderID", "ItemCount", "ItemName", "ItemPrice" },
                values: new object[,]
                {
                    { 2L, 2L, 2f, "بيبسي 1 لتر", 20f },
                    { 3L, 2L, 2f, "ساندوتش برجر", 50f },
                    { 4L, 2L, 1f, "ايس كريم", 10f },
                    { 6L, 3L, 1f, "سفن اب كانز", 5f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CityID",
                table: "Branches",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Cashier_BranchID",
                table: "Cashier",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceHeaderID",
                table: "InvoiceDetails",
                column: "InvoiceHeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeader_BranchID",
                table: "InvoiceHeader",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHeader_CashierID",
                table: "InvoiceHeader",
                column: "CashierID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "InvoiceHeader");

            migrationBuilder.DropTable(
                name: "Cashier");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
