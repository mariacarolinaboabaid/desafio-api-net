using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DesafioAPI.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "VARCHAR", maxLength: 64, nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    Neighborhood = table.Column<string>(type: "VARCHAR", maxLength: 40, nullable: false),
                    BedroomQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    BusinessType = table.Column<string>(type: "VARCHAR", nullable: false),
                    Adress = table.Column<string>(type: "VARCHAR", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", maxLength: 64, nullable: false),
                    Telephone = table.Column<string>(type: "VARCHAR", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    RealStateId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Properties_RealStateId",
                        column: x => x.RealStateId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Adress", "BedroomQuantity", "BusinessType", "Neighborhood", "Title", "Value" },
                values: new object[,]
                {
                    { 1, "Rua dos Tambaquis, 100, Jurerê Internacional, Florianópolis, Santa Catarina, Brasil", 6, "Aluguel", "Jurerê Internacional", "Mansão à beira mar de Jurerê Internacional", 150000000.0 },
                    { 2, "Avenida Governador Irineu Bornhausen, 3600, Agronômica, Florianópolis, Santa Catarina, Brasil", 3, "Venda", "Agronômica", "Apartamento na Beira Mar de Florianópolis", 1500000.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Telephone" },
                values: new object[] { 1, "alexandrenolla@gmail.com", "Alexandre Nolla", "fullstack123", "48999337729" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "ImageUrl", "RealStateId" },
                values: new object[,]
                {
                    { 1, "https://resizedimgs.vivareal.com/fit-in/870x653/named.images.sp/2c98bca226e13c54573f682945d17186/%7Bdescription%7D.jpg", 1 },
                    { 2, "https://resizedimgs.vivareal.com/fit-in/870x653/named.images.sp/88ec4657fe2299025040c796b652e60d/%7Bdescription%7D.jpg", 1 },
                    { 3, "https://resizedimgs.vivareal.com/fit-in/870x653/named.images.sp/ce637ca7ec929cb81758021e64caafa2/%7Bdescription%7D.jpg", 1 },
                    { 4, "https://resizedimgs.vivareal.com/fit-in/870x653/named.images.sp/a4002f5b599a93edc48457f36d421557/%7Bdescription%7D.jpg", 2 },
                    { 5, "https://resizedimgs.vivareal.com/fit-in/870x653/named.images.sp/7b43c8d9330b4ac163f0f97498ca5fc6/%7Bdescription%7D.jpg", 2 },
                    { 6, "https://resizedimgs.vivareal.com/fit-in/870x653/named.images.sp/95ebb9c47c5562310fd3fc67a4489329/%7Bdescription%7D.jpg", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_RealStateId",
                table: "Photos",
                column: "RealStateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
