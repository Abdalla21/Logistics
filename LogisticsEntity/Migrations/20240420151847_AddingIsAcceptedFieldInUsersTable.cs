using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsEntity.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsAcceptedFieldInUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsAccepted",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "IsAccepted", "PasswordHash", "VerificationCodeExpireDate" },
                values: new object[] { "4/20/2024 5:18:47 PM", null, "$2a$11$RxRYtMbeu/P/MCYgenCCmOSLkKJvdNx14HzpJNEfcLBHgcwJwOYUm", new DateTime(2024, 4, 20, 17, 28, 47, 14, DateTimeKind.Local).AddTicks(8246) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "users");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "CreatedDateTime", "PasswordHash", "VerificationCodeExpireDate" },
                values: new object[] { "4/20/2024 5:26:56 AM", "$2a$11$JBA94piPMr41MMcYECIJWOYZA8m1KsHBrdtWEeYhba/XP4Vxw6Vcy", new DateTime(2024, 4, 20, 5, 36, 56, 218, DateTimeKind.Local).AddTicks(9676) });
        }
    }
}
