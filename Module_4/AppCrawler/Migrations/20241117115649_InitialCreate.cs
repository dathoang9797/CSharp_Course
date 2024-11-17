using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCrawler.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorKey);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLeaf = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryKey);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    MasterId = table.Column<int>(type: "int", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalPrice = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    DiscountRate = table.Column<int>(type: "int", nullable: false),
                    RatingAverage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReviewCount = table.Column<int>(type: "int", nullable: false),
                    FavouriteCount = table.Column<int>(type: "int", nullable: false),
                    AuthorKey = table.Column<int>(type: "int", nullable: false),
                    CategoriesCategoryKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookKey);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorKey",
                        column: x => x.AuthorKey,
                        principalTable: "Author",
                        principalColumn: "AuthorKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Category_CategoriesCategoryKey",
                        column: x => x.CategoriesCategoryKey,
                        principalTable: "Category",
                        principalColumn: "CategoryKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAttribute",
                columns: table => new
                {
                    BookAttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAttribute", x => x.BookAttributeId);
                    table.ForeignKey(
                        name: "FK_BookAttribute_Book_BookKey",
                        column: x => x.BookKey,
                        principalTable: "Book",
                        principalColumn: "BookKey");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LargeUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediumUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SmallUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Image_Book_BookKey",
                        column: x => x.BookKey,
                        principalTable: "Book",
                        principalColumn: "BookKey");
                });

            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    AttributeKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttributeName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    BookAttributeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.AttributeKey);
                    table.ForeignKey(
                        name: "FK_Attribute_BookAttribute_BookAttributeId",
                        column: x => x.BookAttributeId,
                        principalTable: "BookAttribute",
                        principalColumn: "BookAttributeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_BookAttributeId",
                table: "Attribute",
                column: "BookAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorKey",
                table: "Book",
                column: "AuthorKey");

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoriesCategoryKey",
                table: "Book",
                column: "CategoriesCategoryKey");

            migrationBuilder.CreateIndex(
                name: "IX_BookAttribute_BookKey",
                table: "BookAttribute",
                column: "BookKey");

            migrationBuilder.CreateIndex(
                name: "IX_Image_BookKey",
                table: "Image",
                column: "BookKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "BookAttribute");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
