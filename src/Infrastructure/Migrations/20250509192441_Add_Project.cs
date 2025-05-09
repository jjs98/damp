using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations;

/// <inheritdoc />
public partial class Add_Project : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Projects",
            columns: table => new
            {
                Id = table
                    .Column<int>(type: "integer", nullable: false)
                    .Annotation(
                        "Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                    ),
                Name = table.Column<string>(type: "text", nullable: false),
                Description = table.Column<string>(type: "text", nullable: true),
                Tags = table.Column<string[]>(type: "text[]", nullable: false),
                Dependencies = table.Column<string[]>(type: "text[]", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Projects", x => x.Id);
            }
        );

        migrationBuilder.CreateTable(
            name: "HostedEnvironments",
            columns: table => new
            {
                Id = table
                    .Column<int>(type: "integer", nullable: false)
                    .Annotation(
                        "Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                    ),
                ProjectId = table.Column<int>(type: "integer", nullable: false),
                Url = table.Column<string>(type: "text", nullable: false),
                Environment = table.Column<string>(type: "text", nullable: false),
                Description = table.Column<string>(type: "text", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_HostedEnvironments", x => x.Id);
                table.ForeignKey(
                    name: "FK_HostedEnvironments_Projects_ProjectId",
                    column: x => x.ProjectId,
                    principalTable: "Projects",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade
                );
            }
        );

        migrationBuilder.CreateTable(
            name: "DatabaseConnections",
            columns: table => new
            {
                Id = table
                    .Column<int>(type: "integer", nullable: false)
                    .Annotation(
                        "Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn
                    ),
                HostedEnvironmentId = table.Column<int>(type: "integer", nullable: false),
                DatabaseServer = table.Column<string>(type: "text", nullable: false),
                Database = table.Column<string>(type: "text", nullable: false),
                User = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DatabaseConnections", x => x.Id);
                table.ForeignKey(
                    name: "FK_DatabaseConnections_HostedEnvironments_HostedEnvironmentId",
                    column: x => x.HostedEnvironmentId,
                    principalTable: "HostedEnvironments",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade
                );
            }
        );

        migrationBuilder.CreateIndex(
            name: "IX_DatabaseConnections_HostedEnvironmentId",
            table: "DatabaseConnections",
            column: "HostedEnvironmentId"
        );

        migrationBuilder.CreateIndex(
            name: "IX_HostedEnvironments_ProjectId",
            table: "HostedEnvironments",
            column: "ProjectId"
        );
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "DatabaseConnections");

        migrationBuilder.DropTable(name: "HostedEnvironments");

        migrationBuilder.DropTable(name: "Projects");
    }
}
