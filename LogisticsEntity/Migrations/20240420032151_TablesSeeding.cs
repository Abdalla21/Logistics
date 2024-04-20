using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogisticsEntity.Migrations
{
    /// <inheritdoc />
    public partial class TablesSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RoleDescription",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Governorates",
                columns: new[] { "GovernorateID", "GovernorateName" },
                values: new object[,]
                {
                    { 1, "Alexandria" },
                    { 2, "Aswan" },
                    { 3, "Asyut" },
                    { 4, "Beheira" },
                    { 5, "Beni Suef" },
                    { 6, "Cairo" },
                    { 7, "Dakahlia" },
                    { 8, "Damietta" },
                    { 9, "Faiyum" },
                    { 10, "Gharbia" },
                    { 11, "Giza" },
                    { 12, "Ismailia" },
                    { 13, "Kafr El Sheikh" },
                    { 14, "Luxor" },
                    { 15, "Matrouh" },
                    { 16, "Minya" },
                    { 17, "Monufia" },
                    { 18, "New Valley" },
                    { 19, "North Sinai" },
                    { 20, "Port Said" },
                    { 21, "Qalyubia" },
                    { 22, "Qena" },
                    { 23, "Red Sea" },
                    { 24, "Sharqia" },
                    { 25, "Sohag" },
                    { 26, "South Sinai" },
                    { 27, "Suez" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "RoleDescription", "RoleName" },
                values: new object[,]
                {
                    { 1, "Has All The privileges for the current tenant.", "Admin" },
                    { 2, "Has All The privileges for the current Branch.", "Branch Manager" },
                    { 3, "Can see the materials which is lacking in the branches.", "Logistic" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UserID", "Age", "CreatedDateTime", "Email", "IsVerified", "PasswordHash", "Phone", "Role", "UserName", "VerificationCode", "VerificationCodeExpireDate" },
                values: new object[] { 1, 26, "4/20/2024 5:21:51 AM", "abdalla.ahly@gmail.com", true, "$2a$11$v99OqSGJGN/8rHYj4K07NecnjoNYiHQt/ohTePlRDTXBLzZePp6w6", "01096796098", "Admin", "Admin", null, new DateTime(2024, 4, 20, 5, 36, 56, 218, DateTimeKind.Local).AddTicks(9676) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Governorates",
                keyColumn: "GovernorateID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "RoleDescription",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
