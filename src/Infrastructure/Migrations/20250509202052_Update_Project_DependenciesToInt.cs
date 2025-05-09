using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations;

/// <inheritdoc />
public partial class Update_Project_DependenciesToInt : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(name: "Dependencies", table: "Projects");
        migrationBuilder.AddColumn<string[]>(
            name: "Dependencies",
            table: "Projects",
            type: "int[]",
            nullable: false,
            defaultValue: Array.Empty<int>()
        );
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(name: "Dependencies", table: "Projects");
        migrationBuilder.AddColumn<string[]>(
            name: "Dependencies",
            table: "Projects",
            type: "text[]",
            nullable: false,
            defaultValue: Array.Empty<string>()
        );
    }
}
