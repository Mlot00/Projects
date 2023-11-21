using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class addUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff0a3f4f-ca9e-47d7-b4d9-fea72f647339",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f8a13e6-c6b3-4a1e-a066-66576cc829f5", "AQAAAAIAAYagAAAAEO+ulOVcb7gnFzGdTZqIDfcdVwa/g3jbBXitjHL42tbqOaw6SGnXTMSLfzweoqtXHQ==", "59dba74c-3146-4dca-a8ea-182cbef6b3eb" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "857f538b-8a44-4d46-ad57-53578bddda08", 0, "aca5b1dd-10ea-4c52-b9e7-173c0b3bed6b", "user2@webapp.com", false, false, null, "USER2@WEBAPP.COM", "USER2@WEBAPP.COM", "AQAAAAIAAYagAAAAEHGbiJo0FsrB7UC40HlVwAFOZ2u2cREWWyPGDrClSfa8BxO6feSH9R+2iuEGmES+9g==", null, false, "867f4dec-6d75-4fb8-96cc-5f67d2b96b0b", false, "user2@webapp.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a9965675-7f3f-4b3e-8b69-f1c18fc14057", "857f538b-8a44-4d46-ad57-53578bddda08" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a9965675-7f3f-4b3e-8b69-f1c18fc14057", "857f538b-8a44-4d46-ad57-53578bddda08" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "857f538b-8a44-4d46-ad57-53578bddda08");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff0a3f4f-ca9e-47d7-b4d9-fea72f647339",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1537aa0-cf15-4ca7-88e5-5815ac603d6c", "AQAAAAIAAYagAAAAEIJnAuTuq/9jEM5uohs3AoVu/MesZ1oDcL/rNm16ioy/zdvDwjfaLS/K0m9gxTxiRg==", "d050198a-3b57-432c-a8a2-03da9f1ae0c7" });
        }
    }
}
