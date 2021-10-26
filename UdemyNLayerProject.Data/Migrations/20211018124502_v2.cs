using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyNLayerProject.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    InnerBarcode = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "IsDeleted", "Name" },
                values: new object[] { 1, false, "Kalemler" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "IsDeleted", "Name" },
                values: new object[] { 2, false, "Defterler" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "InnerBarcode", "IsDeleted", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, null, false, "Pilot Kalem", 12.50m, 100 },
                    { 2, 1, null, false, "Kurşun Kalem", 40.50m, 200 },
                    { 3, 1, null, false, "Tükenmez Kalem", 500m, 300 },
                    { 5, 2, null, false, "Küçük Boy Defter", 12.50m, 100 },
                    { 6, 2, null, false, "Orta Boy Defter", 22.50m, 150 },
                    { 7, 2, null, false, "Büyük Boy Defter", 32.50m, 200 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
