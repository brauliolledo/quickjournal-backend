using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quickjournal_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddImportantColumnToEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>("important", "entry", "Boolean", null, null, false, null, false, false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("important", "entry");
        }
    }
}
