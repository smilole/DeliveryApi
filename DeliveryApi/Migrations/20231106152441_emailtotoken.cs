using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryApi.Migrations
{
    /// <inheritdoc />
    public partial class emailtotoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailToTokens",
                columns: table => new
                {
                    email = table.Column<string>(type: "text", nullable: false),
                    token = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailToTokens", x => x.email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailToTokens");
        }
    }
}
