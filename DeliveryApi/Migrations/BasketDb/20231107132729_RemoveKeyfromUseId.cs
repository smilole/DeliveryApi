using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryApi.Migrations.BasketDb
{
    /// <inheritdoc />
    public partial class RemoveKeyfromUseId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DishInBasket",
                table: "DishInBasket");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_DishInBasket",
                table: "DishInBasket",
                column: "UserId");
        }
    }
}
