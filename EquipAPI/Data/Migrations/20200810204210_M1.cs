using Microsoft.EntityFrameworkCore.Migrations;

namespace EquipAPI.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equips",
                columns: table => new
                {
                    EquipsId = table.Column<string>(nullable: false),
                    EquipName = table.Column<string>(nullable: false),
                    EquipCount = table.Column<string>(nullable: false),
                    EquipType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equips", x => x.EquipsId);
                });

            migrationBuilder.InsertData(
                table: "Equips",
                columns: new[] { "EquipsId", "EquipCount", "EquipName", "EquipType" },
                values: new object[,]
                {
                    { "e2c06985-9610-4962-8763-ee3d98e7c5c4", "1", "Voidbow", "bow" },
                    { "4aef9cce-ba8e-4a65-9ed4-668e9ac768ef", "15", "Leafbow", "bow" },
                    { "37bbe97c-a244-4d48-8cbb-373bb24380c9", "10", "Doombow", "bow" },
                    { "36d90c21-35bf-44ef-940d-55c5ca2144be", "25", "Coralbow", "bow" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equips");
        }
    }
}
