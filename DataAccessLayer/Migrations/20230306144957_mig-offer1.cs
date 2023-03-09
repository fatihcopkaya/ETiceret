using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migoffer1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiveUserId",
                table: "Offer");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "8091bb2a4d184f4396de7eeb90834c7a", "2630a5c03be59fd3aa0b0438ac597d8b30662ca27c303b971305378a4520a45db10731ecbb7990ee1dbfb40570558fadc1d419ac7f4898a72c76a06911066bb2", "574ffc04fcdc41b2a5b868cd571878ff3/6/202354957PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GiveUserId",
                table: "Offer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "ef1b144f53464d5c987f513ccfec4289", "b1fb192fc23cc8df6edaa7aa746002938bf4338ce9da4368996b1d9b1fca9d4d3b4ae77a8cd80d49ef4bdcda0a1ca79a825a838c482666fa12efedfcb8632919", "b612253e7a5541c39eab49da0d22268f3/6/202353733PM" });
        }
    }
}
