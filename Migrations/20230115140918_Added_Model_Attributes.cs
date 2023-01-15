using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class Added_Model_Attributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "106b6afd-8ab4-4bff-88f1-2a39bec84f2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e016074e-1e38-4a36-8ada-028b990c2bbe");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rate",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a3e4493b-b6fd-4634-9905-824a03377827", "0d062ce3-4185-4678-8e0c-16ff38b40a7d", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e89752ce-5e87-43f0-afef-cb6c50038623", "71b93729-75ed-44b4-af87-22288a066aa6", "Tutor", "TUTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3e4493b-b6fd-4634-9905-824a03377827");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e89752ce-5e87-43f0-afef-cb6c50038623");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "106b6afd-8ab4-4bff-88f1-2a39bec84f2d", "b51c7860-3daa-4901-bb31-859c541e70d9", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e016074e-1e38-4a36-8ada-028b990c2bbe", "03dc754d-dac1-4ca5-9c11-faf3f7fd9bc4", "Tutor", "TUTOR" });
        }
    }
}
