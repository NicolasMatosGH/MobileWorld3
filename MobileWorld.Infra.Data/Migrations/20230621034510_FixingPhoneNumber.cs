using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileWorld.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixingPhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                table: "mw_Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 21, 0, 45, 10, 630, DateTimeKind.Local).AddTicks(3118),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 19, 20, 44, 0, 825, DateTimeKind.Local).AddTicks(1249));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "mw_Client",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRegister",
                table: "mw_Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 19, 20, 44, 0, 825, DateTimeKind.Local).AddTicks(1249),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 21, 0, 45, 10, 630, DateTimeKind.Local).AddTicks(3118));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "mw_Client",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }
    }
}
