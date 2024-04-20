using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsEntity.Migrations
{
    /// <inheritdoc />
    public partial class TablesSeeding2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "VerificationCodeExpireDate",
                table: "users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "PasswordHash", "VerificationCodeExpireDate" },
                values: new object[] { "4/20/2024 5:26:56 AM", "$2a$11$JBA94piPMr41MMcYECIJWOYZA8m1KsHBrdtWEeYhba/XP4Vxw6Vcy", new DateTime(2024, 4, 20, 5, 36, 56, 218, DateTimeKind.Local).AddTicks(9676) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "VerificationCodeExpireDate",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "PasswordHash", "VerificationCodeExpireDate" },
                values: new object[] { "4/20/2024 5:21:51 AM", "$2a$11$v99OqSGJGN/8rHYj4K07NecnjoNYiHQt/ohTePlRDTXBLzZePp6w6", new DateTime(2024, 4, 20, 5, 31, 51, 354, DateTimeKind.Local).AddTicks(5323) });
        }
    }
}
