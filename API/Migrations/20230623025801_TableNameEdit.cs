using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class TableNameEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_account_educations_tb_m_employees_guid",
                table: "tb_m_account_educations");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_account_educations_tb_m_universities_university_guid",
                table: "tb_m_account_educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_account_educations",
                table: "tb_m_account_educations");

            migrationBuilder.RenameTable(
                name: "tb_m_account_educations",
                newName: "tb_m_educations");

            migrationBuilder.RenameIndex(
                name: "IX_tb_m_account_educations_university_guid",
                table: "tb_m_educations",
                newName: "IX_tb_m_educations_university_guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_educations",
                table: "tb_m_educations",
                column: "guid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_educations_tb_m_employees_guid",
                table: "tb_m_educations",
                column: "guid",
                principalTable: "tb_m_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_educations_tb_m_universities_university_guid",
                table: "tb_m_educations",
                column: "university_guid",
                principalTable: "tb_m_universities",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_educations_tb_m_employees_guid",
                table: "tb_m_educations");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_educations_tb_m_universities_university_guid",
                table: "tb_m_educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_educations",
                table: "tb_m_educations");

            migrationBuilder.RenameTable(
                name: "tb_m_educations",
                newName: "tb_m_account_educations");

            migrationBuilder.RenameIndex(
                name: "IX_tb_m_educations_university_guid",
                table: "tb_m_account_educations",
                newName: "IX_tb_m_account_educations_university_guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_account_educations",
                table: "tb_m_account_educations",
                column: "guid");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_account_educations_tb_m_employees_guid",
                table: "tb_m_account_educations",
                column: "guid",
                principalTable: "tb_m_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_account_educations_tb_m_universities_university_guid",
                table: "tb_m_account_educations",
                column: "university_guid",
                principalTable: "tb_m_universities",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
