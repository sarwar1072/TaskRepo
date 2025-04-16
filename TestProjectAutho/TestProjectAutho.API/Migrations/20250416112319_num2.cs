using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProjectAuthoAPI.Migrations
{
    /// <inheritdoc />
    public partial class num2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638804209990812739");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638804209990812761");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "Password", "PasswordHash" },
                values: new object[] { "75e7eaf7-6a1e-411f-86a9-994e01b8ec2e", null, "AQAAAAIAAYagAAAAEM7C6EOvMGBB87Om6hTjzD1dY+L3+zNK4gasm6ost+jaIwxHmRgXXaCFLZgmWRWxXA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "Password", "PasswordHash" },
                values: new object[] { "0a5fd7ba-9a03-44a7-a22e-a6250e7a148b", null, "AQAAAAIAAYagAAAAELgYRd8BC3WMACOzSEA8naNj+joTQ9Eif8Tji4/aD0s3D31Z0bzUv5YgiWUI+X7dyw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c5e174e-3b0e-446f-86af-483d56fd7210"),
                column: "ConcurrencyStamp",
                value: "638804067047663583");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e943ffbf-65a4-4d42-bb74-f2ca9ea8d22a"),
                column: "ConcurrencyStamp",
                value: "638804067047663619");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f3d96ce-76ec-4992-911a-33ceb81fa29d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2fa3ff8e-38da-456f-a058-341b41076335", "AQAAAAIAAYagAAAAEF/DSyB3egl0nPyM1qdmQzCckvgef22YSWPRbVGbWMlSasc812NQNRa1XCa5kFBQtw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fa49451c-1d42-4e4f-abea-50ba4c60eda5", "AQAAAAIAAYagAAAAECmd0KdLX1416Jg4zdaoGiCRPMhMwxlld3wjOIbS85bHAoxlvG1FjGC64pbBKL8OUw==" });
        }
    }
}
