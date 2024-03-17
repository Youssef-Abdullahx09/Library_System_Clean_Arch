using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguredAuthTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHashed = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppFeaturePermissions",
                columns: table => new
                {
                    AppFeatureId = table.Column<int>(type: "int", nullable: false),
                    AppPermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFeaturePermissions", x => new { x.AppFeatureId, x.AppPermissionId });
                    table.ForeignKey(
                        name: "FK_AppFeaturePermissions_AppFeatures_AppFeatureId",
                        column: x => x.AppFeatureId,
                        principalTable: "AppFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppFeaturePermissions_AppPermissions_AppPermissionId",
                        column: x => x.AppPermissionId,
                        principalTable: "AppPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserProfiles",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserProfiles", x => new { x.AppUserId, x.AppProfileId });
                    table.ForeignKey(
                        name: "FK_AppUserProfiles_AppProfiles_AppProfileId",
                        column: x => x.AppProfileId,
                        principalTable: "AppProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserProfiles_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppProfilePermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppProfileId = table.Column<int>(type: "int", nullable: false),
                    AppFeaturePermissionAppFeatureId = table.Column<int>(type: "int", nullable: false),
                    AppFeaturePermissionAppPermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProfilePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppProfilePermissions_AppFeaturePermissions_AppFeaturePermissionAppFeatureId_AppFeaturePermissionAppPermissionId",
                        columns: x => new { x.AppFeaturePermissionAppFeatureId, x.AppFeaturePermissionAppPermissionId },
                        principalTable: "AppFeaturePermissions",
                        principalColumns: new[] { "AppFeatureId", "AppPermissionId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppProfilePermissions_AppProfiles_AppProfileId",
                        column: x => x.AppProfileId,
                        principalTable: "AppProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppFeatures",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, "Identity", "الهويه" },
                    { 2, "Books", "الكتب" }
                });

            migrationBuilder.InsertData(
                table: "AppPermissions",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, "List", "الفهرسه" },
                    { 2, "Create", "الاضافه" },
                    { 3, "Update", "التعديل" },
                    { 4, "Delete", "المسح" }
                });

            migrationBuilder.InsertData(
                table: "AppProfiles",
                columns: new[] { "Id", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, "Owner", "مالك النظام" },
                    { 2, "Admin", "مدير النظام" }
                });

            migrationBuilder.InsertData(
                table: "AppFeaturePermissions",
                columns: new[] { "AppFeatureId", "AppPermissionId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppFeaturePermissions_AppPermissionId",
                table: "AppFeaturePermissions",
                column: "AppPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProfilePermissions_AppFeaturePermissionAppFeatureId_AppFeaturePermissionAppPermissionId",
                table: "AppProfilePermissions",
                columns: new[] { "AppFeaturePermissionAppFeatureId", "AppFeaturePermissionAppPermissionId" });

            migrationBuilder.CreateIndex(
                name: "IX_AppProfilePermissions_AppProfileId",
                table: "AppProfilePermissions",
                column: "AppProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserProfiles_AppProfileId",
                table: "AppUserProfiles",
                column: "AppProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppProfilePermissions");

            migrationBuilder.DropTable(
                name: "AppUserProfiles");

            migrationBuilder.DropTable(
                name: "AppFeaturePermissions");

            migrationBuilder.DropTable(
                name: "AppProfiles");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "AppFeatures");

            migrationBuilder.DropTable(
                name: "AppPermissions");
        }
    }
}
