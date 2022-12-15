using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
	public partial class CreateDomain : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "supplier",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Cnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
					CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
					UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_supplier", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "product",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Situation = table.Column<bool>(type: "bit", nullable: false),
					FabricatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
					ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
					SupplierId = table.Column<long>(type: "bigint", nullable: true),
					CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
					UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_product", x => x.Id);
					table.ForeignKey(
						name: "FK_product_supplier_SupplierId",
						column: x => x.SupplierId,
						principalTable: "supplier",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_product_SupplierId",
				table: "product",
				column: "SupplierId",
				unique: true,
				filter: "[SupplierId] IS NOT NULL");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "product");

			migrationBuilder.DropTable(
				name: "supplier");
		}
	}
}
