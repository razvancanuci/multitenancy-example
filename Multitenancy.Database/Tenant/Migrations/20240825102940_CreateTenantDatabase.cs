using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Multitenancy.Database.Tenant.Migrations
{
    /// <inheritdoc />
    public partial class CreateTenantDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "tenant");

            migrationBuilder.CreateTable(
                name: "Data",
                schema: "tenant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Field = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Attribute = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "tenant",
                table: "Data",
                columns: new[] { "Id", "Attribute", "Field" },
                values: new object[,]
                {
                    { 1, "attrib", "field" },
                    { 2, "attrib2", "field2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Data",
                schema: "tenant");
        }
    }
}
