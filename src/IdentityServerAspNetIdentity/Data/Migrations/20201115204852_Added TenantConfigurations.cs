using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityServerAspNetIdentity.Data.Migrations
{
    public partial class AddedTenantConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TenantConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenantID = table.Column<int>(nullable: false),
                    ClientId = table.Column<string>(nullable: true),
                    Domain = table.Column<string>(nullable: true),
                    ExternalProviderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalProviders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Scheme = table.Column<string>(nullable: true),
                    TenantConfigurationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalProviders_TenantConfigurations_TenantConfigurationId",
                        column: x => x.TenantConfigurationId,
                        principalTable: "TenantConfigurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalProviders_TenantConfigurationId",
                table: "ExternalProviders",
                column: "TenantConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantConfigurations_ExternalProviderId",
                table: "TenantConfigurations",
                column: "ExternalProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantConfigurations_ExternalProviders_ExternalProviderId",
                table: "TenantConfigurations",
                column: "ExternalProviderId",
                principalTable: "ExternalProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExternalProviders_TenantConfigurations_TenantConfigurationId",
                table: "ExternalProviders");

            migrationBuilder.DropTable(
                name: "TenantConfigurations");

            migrationBuilder.DropTable(
                name: "ExternalProviders");
        }
    }
}
