using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class tbProductadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Tom Cruis", "Army pilots", "F5435354bjh", 25.0, 25.0, 30.0, 26.0, "Top Gun" },
                    { 2, "Leonardo D", " The most bigger movie of all time", "F5498754NN", 35.0, 75.0, 50.0, 66.0, "Titanic" },
                    { 3, "D.B.", "Disney", "F5435354AAA", 29.0, 28.0, 31.0, 26.0, "Marvel" },
                    { 4, "Chris T", "Disney", "F54353VYGJH", 15.0, 65.0, 36.0, 36.0, "Thor" },
                    { 5, "T.Cris", "Love Santa", "F543532528A", 15.0, 15.0, 20.0, 16.0, "Last Christmas" },
                    { 6, "L.Deep", "Dancer ,love, discovery", "F543535MM55", 25.0, 25.0, 30.0, 26.0, "The Idol" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
