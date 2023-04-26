using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Studens",
                columns: new[] { "ID", "CreatedDate", "FirstName", "Gender", "LastName", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 21, 1, 17, 57, 598, DateTimeKind.Local).AddTicks(3548), "Emirhan", 0, "sürücü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, new DateTime(2023, 4, 21, 1, 17, 57, 598, DateTimeKind.Local).AddTicks(5911), "Seden", 1, "sürücü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 3, new DateTime(2023, 4, 21, 1, 17, 57, 598, DateTimeKind.Local).AddTicks(5924), "İbrahim", 0, "sürücü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 4, new DateTime(2023, 4, 21, 1, 17, 57, 598, DateTimeKind.Local).AddTicks(5928), "Emine", 1, "sürücü", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CreatedDate", "ModifiedDate", "Password", "Role", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 4, 21, 1, 17, 57, 593, DateTimeKind.Local).AddTicks(3504), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$WFuiG9S9z7m6LO1Ma9c9/OyulupcgMNoJMgg/w3PIcppSfyHCR2GO", 1, 0, "administrator" },
                    { 2, new DateTime(2023, 4, 21, 1, 17, 57, 595, DateTimeKind.Local).AddTicks(6497), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$KQ1tZATBa7YGdRdtBVv1se7pb60CJlJRUa2m6EVX4DJmkYzm7sagG", 2, 0, "alperen" }
                });

            migrationBuilder.InsertData(
                table: "StudentDetail",
                columns: new[] { "ID", "BirthDay", "CreatedDate", "ModifiedDate", "PhoneNumber", "SchoolNumber", "Status", "StudentID" },
                values: new object[,]
                {
                    { 1, new DateTime(1997, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 21, 1, 17, 57, 598, DateTimeKind.Local).AddTicks(7278), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "100", 0, 1 },
                    { 2, new DateTime(1992, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 21, 1, 17, 57, 598, DateTimeKind.Local).AddTicks(9576), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "101", 0, 2 },
                    { 3, new DateTime(1997, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 21, 1, 17, 57, 598, DateTimeKind.Local).AddTicks(9590), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "102", 0, 3 },
                    { 4, new DateTime(1990, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 21, 1, 17, 57, 598, DateTimeKind.Local).AddTicks(9594), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "103", 0, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Studens",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Studens",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Studens",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Studens",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
