using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting.Migrations
{
    /// <inheritdoc />
    public partial class aaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batch");

            migrationBuilder.DropTable(
                name: "Code");

            migrationBuilder.DropTable(
                name: "Ral");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Barrel_ProviderCode",
                table: "Barrel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Barrel_ProviderCode",
                table: "Barrel",
                column: "ProviderCode");

            migrationBuilder.CreateTable(
                name: "Batch",
                columns: table => new
                {
                    BatchNumber = table.Column<string>(type: "text", nullable: false),
                    AttestationStatus = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batch", x => x.BatchNumber);
                    table.ForeignKey(
                        name: "FK_Batch_Barrel_BatchNumber",
                        column: x => x.BatchNumber,
                        principalTable: "Barrel",
                        principalColumn: "ProviderCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Code",
                columns: table => new
                {
                    MaterialCode = table.Column<string>(type: "text", nullable: false),
                    Gloss = table.Column<string>(type: "text", nullable: true),
                    Material = table.Column<string>(type: "text", nullable: true),
                    MaterialType = table.Column<string>(type: "text", nullable: true),
                    ProviderName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Code", x => x.MaterialCode);
                    table.ForeignKey(
                        name: "FK_Code_Barrel_MaterialCode",
                        column: x => x.MaterialCode,
                        principalTable: "Barrel",
                        principalColumn: "ProviderCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ral",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ral", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batch_BatchNumber",
                table: "Batch",
                column: "BatchNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Code_MaterialCode",
                table: "Code",
                column: "MaterialCode");

            migrationBuilder.CreateIndex(
                name: "IX_Ral_Code",
                table: "Ral",
                column: "Code");
        }
    }
}
