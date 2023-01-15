using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class Added_UserType_Attribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3e4493b-b6fd-4634-9905-824a03377827");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e89752ce-5e87-43f0-afef-cb6c50038623");

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2bb0b252-6a45-4d24-b454-73b3aa841166", "3234bbd1-ee43-4d1c-841e-e0939ad4a6ab", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7de00a94-905c-4dd5-94eb-ae9417f2a8c1", "69d14eec-9664-4f3e-aae6-342d1b1b9cba", "Tutor", "TUTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bb0b252-6a45-4d24-b454-73b3aa841166");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7de00a94-905c-4dd5-94eb-ae9417f2a8c1");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a3e4493b-b6fd-4634-9905-824a03377827", "0d062ce3-4185-4678-8e0c-16ff38b40a7d", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e89752ce-5e87-43f0-afef-cb6c50038623", "71b93729-75ed-44b4-af87-22288a066aa6", "Tutor", "TUTOR" });
        }
    }
}
