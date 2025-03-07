using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CRJ_Shop.Migrations
{
    /// <inheritdoc />
    public partial class AddAppUser1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79298828-2105-4022-8c18-e0a7b9172f3b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "82f103bb-25eb-4416-84c8-960f4be036c4", "537a5b04-8496-4129-bd44-8a4fe1c9e0d0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82f103bb-25eb-4416-84c8-960f4be036c4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "537a5b04-8496-4129-bd44-8a4fe1c9e0d0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7cdb0eef-5ecd-45ff-a11b-54e1abbd47ca", null, "User", "USER" },
                    { "a472a22d-72f4-450f-b011-49cdc304e24c", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b4ca5a25-cf47-491e-a0b0-21a01d05d7b4", 0, "06589aa2-6d63-4e21-9188-2166b290cd4b", "admin@test.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEADRJSR4ocRUKQVLNvP5VEhZGhlOE8WjI94GP3Y/XRIy7Ii5i6CDm9ZU0AN+S4J8Kg==", null, false, "27f3cd33-a162-48e9-8992-c68e2a2f6383", false, "admin@test.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a472a22d-72f4-450f-b011-49cdc304e24c", "b4ca5a25-cf47-491e-a0b0-21a01d05d7b4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cdb0eef-5ecd-45ff-a11b-54e1abbd47ca");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a472a22d-72f4-450f-b011-49cdc304e24c", "b4ca5a25-cf47-491e-a0b0-21a01d05d7b4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a472a22d-72f4-450f-b011-49cdc304e24c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4ca5a25-cf47-491e-a0b0-21a01d05d7b4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79298828-2105-4022-8c18-e0a7b9172f3b", null, "User", "USER" },
                    { "82f103bb-25eb-4416-84c8-960f4be036c4", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "537a5b04-8496-4129-bd44-8a4fe1c9e0d0", 0, "7335e041-8f69-4c4d-9b45-18a2cc562f94", null, false, false, null, null, null, "AQAAAAIAAYagAAAAEHAu804PTrEKm+y/Ag5zhx0R2aabSsrxd4W0XXJvWf7cWkwDYyotr8FLyThqf+MDuA==", null, false, "aa151085-a710-43c4-91e3-33f7a3d28690", false, "admin@test.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "82f103bb-25eb-4416-84c8-960f4be036c4", "537a5b04-8496-4129-bd44-8a4fe1c9e0d0" });
        }
    }
}
