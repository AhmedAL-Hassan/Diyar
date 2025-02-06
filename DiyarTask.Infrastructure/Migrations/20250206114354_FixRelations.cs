using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiyarTask.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodeEnum",
                table: "NotificationTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_CreatedDate",
                table: "Reminders",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SentDateUtc",
                table: "Notifications",
                column: "SentDateUtc");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CreatedDate",
                table: "Invoices",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PaymentStatus",
                table: "Invoices",
                column: "PaymentStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CreatedDate",
                table: "Customers",
                column: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reminders_CreatedDate",
                table: "Reminders");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_SentDateUtc",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_CreatedDate",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_PaymentStatus",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CreatedDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CodeEnum",
                table: "NotificationTypes");
        }
    }
}
