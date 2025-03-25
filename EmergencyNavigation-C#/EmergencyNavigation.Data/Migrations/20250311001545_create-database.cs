using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyNavigation.Data.Migrations
{
    /// <inheritdoc />
    public partial class createdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfFloor = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VertexCharacterizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VertexCharacterizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Floor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorNumber = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floor_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vertices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    FloorId = table.Column<long>(type: "bigint", nullable: false),
                    MainCharacterizationId = table.Column<long>(type: "bigint", nullable: false),
                    SecondaryCharacterizationId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vertices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vertices_Floor_FloorId",
                        column: x => x.FloorId,
                        principalTable: "Floor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vertices_VertexCharacterizations_MainCharacterizationId",
                        column: x => x.MainCharacterizationId,
                        principalTable: "VertexCharacterizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vertices_VertexCharacterizations_SecondaryCharacterizationId",
                        column: x => x.SecondaryCharacterizationId,
                        principalTable: "VertexCharacterizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edeges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceId = table.Column<long>(type: "bigint", nullable: false),
                    VertexId = table.Column<long>(type: "bigint", nullable: false),
                    Meters = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edeges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edeges_Vertices_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Vertices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Edeges_Vertices_VertexId",
                        column: x => x.VertexId,
                        principalTable: "Vertices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsualLocalId = table.Column<long>(type: "bigint", nullable: false),
                    IsParamedic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Vertices_UsualLocalId",
                        column: x => x.UsualLocalId,
                        principalTable: "Vertices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edeges_SourceId",
                table: "Edeges",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Edeges_VertexId",
                table: "Edeges",
                column: "VertexId");

            migrationBuilder.CreateIndex(
                name: "IX_Floor_BuildingId",
                table: "Floor",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UsualLocalId",
                table: "Users",
                column: "UsualLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Vertices_FloorId",
                table: "Vertices",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vertices_MainCharacterizationId",
                table: "Vertices",
                column: "MainCharacterizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vertices_SecondaryCharacterizationId",
                table: "Vertices",
                column: "SecondaryCharacterizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edeges");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vertices");

            migrationBuilder.DropTable(
                name: "Floor");

            migrationBuilder.DropTable(
                name: "VertexCharacterizations");

            migrationBuilder.DropTable(
                name: "Buildings");
        }
    }
}
