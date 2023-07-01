using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class UpdateNameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_bookings_tb_tr_rooms_room_guid",
                table: "tb_tr_bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_rooms",
                table: "tb_tr_rooms");

            migrationBuilder.RenameTable(
                name: "tb_tr_rooms",
                newName: "tb_m_rooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_rooms",
                table: "tb_m_rooms",
                column: "guid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_bookings_tb_m_rooms_room_guid",
                table: "tb_tr_bookings",
                column: "room_guid",
                principalTable: "tb_m_rooms",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_bookings_tb_m_rooms_room_guid",
                table: "tb_tr_bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_rooms",
                table: "tb_m_rooms");

            migrationBuilder.RenameTable(
                name: "tb_m_rooms",
                newName: "tb_tr_rooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_rooms",
                table: "tb_tr_rooms",
                column: "guid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_bookings_tb_tr_rooms_room_guid",
                table: "tb_tr_bookings",
                column: "room_guid",
                principalTable: "tb_tr_rooms",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
