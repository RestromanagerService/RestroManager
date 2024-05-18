using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restromanager.Backend.Migrations
{
    /// <inheritdoc />
    public partial class deletecascadinginttables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodRawMaterials_Foods_FoodId",
                table: "FoodRawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodRawMaterials_RawMaterials_RawMaterialId",
                table: "FoodRawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodRawMaterials_Units_UnitsId",
                table: "FoodRawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Categories_CategoryId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFoods_Foods_FoodId",
                table: "ProductFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFoods_Products_ProductId",
                table: "ProductFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFoods_Units_UnitsId",
                table: "ProductFoods");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRawMaterials_Foods_FoodId",
                table: "FoodRawMaterials",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRawMaterials_RawMaterials_RawMaterialId",
                table: "FoodRawMaterials",
                column: "RawMaterialId",
                principalTable: "RawMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRawMaterials_Units_UnitsId",
                table: "FoodRawMaterials",
                column: "UnitsId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Categories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFoods_Foods_FoodId",
                table: "ProductFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFoods_Products_ProductId",
                table: "ProductFoods",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFoods_Units_UnitsId",
                table: "ProductFoods",
                column: "UnitsId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodRawMaterials_Foods_FoodId",
                table: "FoodRawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodRawMaterials_RawMaterials_RawMaterialId",
                table: "FoodRawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodRawMaterials_Units_UnitsId",
                table: "FoodRawMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Categories_CategoryId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFoods_Foods_FoodId",
                table: "ProductFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFoods_Products_ProductId",
                table: "ProductFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductFoods_Units_UnitsId",
                table: "ProductFoods");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRawMaterials_Foods_FoodId",
                table: "FoodRawMaterials",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRawMaterials_RawMaterials_RawMaterialId",
                table: "FoodRawMaterials",
                column: "RawMaterialId",
                principalTable: "RawMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRawMaterials_Units_UnitsId",
                table: "FoodRawMaterials",
                column: "UnitsId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Categories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFoods_Foods_FoodId",
                table: "ProductFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFoods_Products_ProductId",
                table: "ProductFoods",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFoods_Units_UnitsId",
                table: "ProductFoods",
                column: "UnitsId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
