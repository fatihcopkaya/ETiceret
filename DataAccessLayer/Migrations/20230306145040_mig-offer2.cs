using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migoffer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "ccee60ccd3f44d56a7cdbd6931eeb737", "78b6eaeb5eff535b57f3b5883160c8a6b715d1f7abf88e02b171590cebbb5dec3e879ade522103eaac565267cd6a13be7b5758ce6b9f5eeaa734a1d1bfcf910e", "237d661d71a64ae6bdaa782af0fc62963/6/202355040PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "8091bb2a4d184f4396de7eeb90834c7a", "2630a5c03be59fd3aa0b0438ac597d8b30662ca27c303b971305378a4520a45db10731ecbb7990ee1dbfb40570558fadc1d419ac7f4898a72c76a06911066bb2", "574ffc04fcdc41b2a5b868cd571878ff3/6/202354957PM" });
        }
    }
}
