using Microsoft.EntityFrameworkCore.Migrations;

namespace ShowRank.WebApi.Migrations
{
    public partial class changed_to_see_list_item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdOfProfileWhoSharedTheOpinion",
                table: "ToSeeListItems");

            migrationBuilder.DropColumn(
                name: "NameOfTheShow",
                table: "ToSeeListItems");

            migrationBuilder.AddColumn<string>(
                name: "IdOfPost",
                table: "ToSeeListItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdOfPost",
                table: "ToSeeListItems");

            migrationBuilder.AddColumn<string>(
                name: "IdOfProfileWhoSharedTheOpinion",
                table: "ToSeeListItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfTheShow",
                table: "ToSeeListItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
