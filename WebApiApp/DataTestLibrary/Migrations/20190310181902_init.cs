using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataTestLibrary.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Property1s",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property1s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Property2s",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property2s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Datas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Prop1Id = table.Column<Guid>(nullable: false),
                    Prop2Id = table.Column<Guid>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Flag = table.Column<bool>(nullable: false),
                    Sum = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Datas_Property1s_Prop1Id",
                        column: x => x.Prop1Id,
                        principalTable: "Property1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Datas_Property2s_Prop2Id",
                        column: x => x.Prop2Id,
                        principalTable: "Property2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    DataId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDatas_Datas_DataId",
                        column: x => x.DataId,
                        principalTable: "Datas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Datas_Prop1Id",
                table: "Datas",
                column: "Prop1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Datas_Prop2Id",
                table: "Datas",
                column: "Prop2Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubDatas_DataId",
                table: "SubDatas",
                column: "DataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubDatas");

            migrationBuilder.DropTable(
                name: "Datas");

            migrationBuilder.DropTable(
                name: "Property1s");

            migrationBuilder.DropTable(
                name: "Property2s");
        }
    }
}
