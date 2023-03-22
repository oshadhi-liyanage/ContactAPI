using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreationTimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CreationTimestamp",
                table: "Contacts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTimestamp",
                table: "Contacts");
        }
    }
}
