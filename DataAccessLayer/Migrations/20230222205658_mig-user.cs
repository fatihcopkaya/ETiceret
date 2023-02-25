using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class miguser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "342a4fbe0d784af1bf093cb8a8f9356a", "de1c3c1dd179ec182a8b69a21fae8d846dac92a67a0918c76726e2130be79fda2b93c66ca309c493d0b8be15161982982bcb21ed36660a8dad91ff6447af6de9", "70e2418e494e4517b999cc087fa5bcce2/22/2023115658PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "943fe01e6948479a90905e9962e797d6", "dd7b8f33bf265b9d3f97cf09c0ada60da6022c6fb61e789cb7f3d78ccf9650ccbb65ce6d9408801a3df39599685a1e2619d93fff9d9e0a07b150e14199412e87", "fea372d72f604c7dba0f2d8d5a41d0d02/21/202361845PM" });
        }
    }
}
