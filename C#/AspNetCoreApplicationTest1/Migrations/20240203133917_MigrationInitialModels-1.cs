using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreApplicationTest1.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInitialModels1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarsCategories",
                columns: table => new
                {
                    ID = table.Column<short>(type: "Smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationUsers_GroupRoles",
                columns: table => new
                {
                    ID = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrayStringPermission = table.Column<string>(type: "nvarchar(max)", maxLength: 65535, nullable: false),
                    ArrayBoolPermission = table.Column<string>(type: "nvarchar(max)", maxLength: 65535, nullable: false),
                    RegistrationUser_PermissionRoleENUM = table.Column<byte>(type: "TinyInt", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationUsers_GroupRoles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    ID = table.Column<short>(type: "Smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<short>(type: "Smallint", nullable: true),
                    CarCategory_ID = table.Column<short>(type: "Smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cars_CarsCategories_CarCategory_ID",
                        column: x => x.CarCategory_ID,
                        principalTable: "CarsCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationUsers",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_MailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HashPassword = table.Column<string>(type: "nvarchar(max)", maxLength: 65535, nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "Date", nullable: false),
                    PermissionGroupRole_ID = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RegistrationUsers_RegistrationUsers_GroupRoles_PermissionGroupRole_ID",
                        column: x => x.PermissionGroupRole_ID,
                        principalTable: "RegistrationUsers_GroupRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationUsers_ContactInformations",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkAccess = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    BirthDay = table.Column<DateTime>(type: "Date", nullable: false),
                    MaleBool = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationUser_ID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationUsers_ContactInformations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RegistrationUsers_ContactInformations_RegistrationUsers_RegistrationUser_ID",
                        column: x => x.RegistrationUser_ID,
                        principalTable: "RegistrationUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationUsers_ImagesAndVideosAlbumsGraph",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Appellation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateTimeCreation = table.Column<DateTime>(type: "Date", nullable: false),
                    RegistrationUser_ID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationUsers_ImagesAndVideosAlbumsGraph", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RegistrationUsers_ImagesAndVideosAlbumsGraph_RegistrationUsers_RegistrationUser_ID",
                        column: x => x.RegistrationUser_ID,
                        principalTable: "RegistrationUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationUsers_ImagesAlbums",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Appellation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateTimeCreation = table.Column<DateTime>(type: "Date", nullable: false),
                    ArrayByteImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImagesAndVideosAlbumsGraph_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationUsers_ImagesAlbums", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RegistrationUsers_ImagesAlbums_RegistrationUsers_ImagesAndVideosAlbumsGraph_ImagesAndVideosAlbumsGraph_ID",
                        column: x => x.ImagesAndVideosAlbumsGraph_ID,
                        principalTable: "RegistrationUsers_ImagesAndVideosAlbumsGraph",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationUsers_VideosAlbums",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Appellation = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DateTimeCreation = table.Column<DateTime>(type: "Date", nullable: false),
                    ArrayByteVideo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImagesAndVideosAlbumsGraph_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationUsers_VideosAlbums", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RegistrationUsers_VideosAlbums_RegistrationUsers_ImagesAndVideosAlbumsGraph_ImagesAndVideosAlbumsGraph_ID",
                        column: x => x.ImagesAndVideosAlbumsGraph_ID,
                        principalTable: "RegistrationUsers_ImagesAndVideosAlbumsGraph",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarCategory_ID",
                table: "Cars",
                column: "CarCategory_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationUsers_PermissionGroupRole_ID",
                table: "RegistrationUsers",
                column: "PermissionGroupRole_ID",
                unique: true,
                filter: "[PermissionGroupRole_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationUsers_ContactInformations_RegistrationUser_ID",
                table: "RegistrationUsers_ContactInformations",
                column: "RegistrationUser_ID",
                unique: true,
                filter: "[RegistrationUser_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationUsers_ImagesAlbums_ImagesAndVideosAlbumsGraph_ID",
                table: "RegistrationUsers_ImagesAlbums",
                column: "ImagesAndVideosAlbumsGraph_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationUsers_ImagesAndVideosAlbumsGraph_RegistrationUser_ID",
                table: "RegistrationUsers_ImagesAndVideosAlbumsGraph",
                column: "RegistrationUser_ID",
                unique: true,
                filter: "[RegistrationUser_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationUsers_VideosAlbums_ImagesAndVideosAlbumsGraph_ID",
                table: "RegistrationUsers_VideosAlbums",
                column: "ImagesAndVideosAlbumsGraph_ID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "RegistrationUsers_ContactInformations");

            migrationBuilder.DropTable(
                name: "RegistrationUsers_ImagesAlbums");

            migrationBuilder.DropTable(
                name: "RegistrationUsers_VideosAlbums");

            migrationBuilder.DropTable(
                name: "CarsCategories");

            migrationBuilder.DropTable(
                name: "RegistrationUsers_ImagesAndVideosAlbumsGraph");

            migrationBuilder.DropTable(
                name: "RegistrationUsers");

            migrationBuilder.DropTable(
                name: "RegistrationUsers_GroupRoles");
        }
    }
}
