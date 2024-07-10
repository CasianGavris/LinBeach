using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinBeach.Migrations.AuthDb
{
    public partial class Normalizedusername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "536727b7-9218-4d43-933f-7d5dc7a9cf82",
                columns: new[] { "Birthdate", "ConcurrencyStamp", "Email", "FullName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { new DateTime(2000, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "08647314-818c-4615-a05e-fa7c066c3c88", "superadmin@linbeach.ro", "superadmin", "SUPERADMIN@LINBEACH.RO", "SUPERADMIN", "AQAAAAEAACcQAAAAEJeEZyEYimAz1dBTjhe/LBefyY7DqbARNLMxF3vT8mibxKtr6jCEPTyOadwQbwzGnQ==", "afb1c0bd-b683-4325-aa4b-5639f5c9a236", "SuperAdmin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "536727b7-9218-4d43-933f-7d5dc7a9cf82",
                columns: new[] { "Birthdate", "ConcurrencyStamp", "Email", "FullName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { new DateTime(2003, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "051fb8cd-4004-4b19-930e-44dc3c7be862", "casian.gavris01@gmail.com", "Casian Gavris", null, null, "AQAAAAEAACcQAAAAEMBh87LFiujbTqL9nG3xvGle5r7PdmkbIMNnaDiS4H4rZ30i1SJ8h5XclFgU7R+gHw==", "b9061ab6-8969-4cbd-9163-80b1494f4671", "Casian" });
        }
    }
}
