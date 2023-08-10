using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstateApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstateType",
                columns: table => new
                {
                    EstateTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateType", x => x.EstateTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Estate",
                columns: table => new
                {
                    EstateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstateTypeId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estate", x => x.EstateId);
                    table.ForeignKey(
                        name: "FK_Estate_EstateType_EstateTypeId",
                        column: x => x.EstateTypeId,
                        principalTable: "EstateType",
                        principalColumn: "EstateTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstateImage",
                columns: table => new
                {
                    EstateImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstateId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateImage", x => x.EstateImageId);
                    table.ForeignKey(
                        name: "FK_EstateImage_Estate_EstateId",
                        column: x => x.EstateId,
                        principalTable: "Estate",
                        principalColumn: "EstateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstateType",
                columns: new[] { "EstateTypeId", "TypeName" },
                values: new object[,]
                {
                    { 1, "Apartment" },
                    { 2, "House" },
                    { 3, "Cabin" }
                });

            migrationBuilder.InsertData(
                table: "Estate",
                columns: new[] { "EstateId", "Address", "Description", "EstateTypeId", "IsSold", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "123 App St.", "No description", 1, false, 200000, null },
                    { 2, "456 House Rd.", "No description", 2, false, 400000, null }
                });

            migrationBuilder.InsertData(
                table: "EstateImage",
                columns: new[] { "EstateImageId", "EstateId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://images.unsplash.com/photo-1515263487990-61b07816b324?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80" },
                    { 2, 2, "https://images.unsplash.com/photo-1625602812206-5ec545ca1231?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1170&q=80" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estate_EstateTypeId",
                table: "Estate",
                column: "EstateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EstateImage_EstateId",
                table: "EstateImage",
                column: "EstateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstateImage");

            migrationBuilder.DropTable(
                name: "Estate");

            migrationBuilder.DropTable(
                name: "EstateType");
        }
    }
}
