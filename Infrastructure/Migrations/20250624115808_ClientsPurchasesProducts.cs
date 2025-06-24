using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClientsPurchasesProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    second_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: false),
                    registration_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    category = table.Column<int>(type: "integer", maxLength: 100, nullable: false),
                    sku = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    total_amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    client_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.id);
                    table.ForeignKey(
                        name: "FK_Purchases_Clients_client_id",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItems",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    purchase_id = table.Column<int>(type: "integer", nullable: false),
                    product_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItems", x => x.id);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Purchases_purchase_id",
                        column: x => x.purchase_id,
                        principalTable: "Purchases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "id", "birth_date", "name", "last_name", "registration_date", "second_name" },
                values: new object[,]
                {
                    { 1, new DateOnly(1980, 7, 31), "Гаррі", "Потеренко", new DateTime(2023, 12, 31, 22, 0, 0, 0, DateTimeKind.Utc), "Джеймсевіч" },
                    { 2, new DateOnly(1980, 6, 5), "Драко", "Малфоєнко", new DateTime(2024, 2, 1, 22, 0, 0, 0, DateTimeKind.Utc), "Луціюсевіч" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "category", "name", "price", "sku" },
                values: new object[,]
                {
                    { 1, 0, "Laptop Lenovo", 2500m, "SKU123" },
                    { 2, 1, "CellPhone Samsung", 1800m, "SKU456" },
                    { 3, 2, "Ipad", 2000m, "M4" }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "id", "client_id", "date", "number", "total_amount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 9, 22, 0, 0, 0, DateTimeKind.Utc), "0503002010", 3500m },
                    { 2, 2, new DateTime(2024, 4, 19, 21, 0, 0, 0, DateTimeKind.Utc), "0503002011", 2000m }
                });

            migrationBuilder.InsertData(
                table: "PurchaseItems",
                columns: new[] { "id", "product_id", "purchase_id", "quantity", "unit_price" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 2500m },
                    { 2, 2, 1, 1, 1000m },
                    { 3, 3, 2, 1, 2000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_product_id",
                table: "PurchaseItems",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_purchase_id",
                table: "PurchaseItems",
                column: "purchase_id");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_client_id",
                table: "Purchases",
                column: "client_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
