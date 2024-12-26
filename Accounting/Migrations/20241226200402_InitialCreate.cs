using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accounting.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barrel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ProviderCode = table.Column<string>(type: "text", nullable: false),
                    Ral = table.Column<string>(type: "text", nullable: false),
                    Batch = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    NettoWeight = table.Column<double>(type: "double precision", nullable: false),
                    BruttoWeight = table.Column<double>(type: "double precision", nullable: false),
                    ProductionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    IsDrained = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StorageObjectId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barrel", x => x.Id);
                    table.UniqueConstraint("AK_Barrel_ProviderCode", x => x.ProviderCode);
                });

            migrationBuilder.CreateTable(
                name: "Journal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BarrelId = table.Column<string>(type: "text", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OperationPayload = table.Column<string>(type: "text", nullable: false),
                    OperationType = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    StorageObjectId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DefaultStoragePlaceId = table.Column<Guid>(type: "uuid", nullable: true),
                    StorageTypeDiscriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                });

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
                name: "StorageObject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Barcode = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StorageId = table.Column<Guid>(type: "uuid", nullable: false),
                    StorageObjectTypeDiscriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    Volume = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageObject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageObject_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_StorageObject_StorageId",
                table: "StorageObject",
                column: "StorageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batch");

            migrationBuilder.DropTable(
                name: "Code");

            migrationBuilder.DropTable(
                name: "Journal");

            migrationBuilder.DropTable(
                name: "Ral");

            migrationBuilder.DropTable(
                name: "StorageObject");

            migrationBuilder.DropTable(
                name: "Barrel");

            migrationBuilder.DropTable(
                name: "Storage");
        }
    }
}
