using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    PhotoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AlbumId = table.Column<string>(nullable: true),
                    ImageId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photos_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { "3fdaec2a-be17-4c3c-b50e-72ff0eec2440", "Desc 1", "Album 1" },
                    { "b392f290-0e40-44a5-962b-4093cc31f65d", "Desc 2 new", "Album 2" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "PhotoId", "Url" },
                values: new object[,]
                {
                    { "1eca8c4c-c7c0-447f-9287-f451c0520c28", "462e23ca-f944-49f2-bcb5-4be963b1a327", "https://avatars.mds.yandex.net/get-pdb/1105309/b26948f0-22ce-41a3-a690-770e9cbf92ce/s1200" },
                    { "bdbb4f26-ae4b-4a29-a5b0-8ae4fad81845", "e2193657-e924-4967-99ce-adc3d0daa9de", "https://avatars.mds.yandex.net/get-pdb/805781/e9f31bb4-e65d-4ccf-8a5f-36b74d8a75be/s1200" }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "AlbumId", "ImageId" },
                values: new object[] { "462e23ca-f944-49f2-bcb5-4be963b1a327", "3fdaec2a-be17-4c3c-b50e-72ff0eec2440", "1eca8c4c-c7c0-447f-9287-f451c0520c28" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "AlbumId", "ImageId" },
                values: new object[] { "e2193657-e924-4967-99ce-adc3d0daa9de", "3fdaec2a-be17-4c3c-b50e-72ff0eec2440", "bdbb4f26-ae4b-4a29-a5b0-8ae4fad81845" });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AlbumId",
                table: "Photos",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ImageId",
                table: "Photos",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}