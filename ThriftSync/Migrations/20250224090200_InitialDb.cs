using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThriftSync.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Period = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DefaultCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    IconUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tags = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    TargetAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrentAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Format = table.Column<int>(type: "integer", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DefaultCategories",
                columns: new[] { "Id", "IconUrl", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("a3b9c1d2-e5f6-4a7b-8c9d-123456789001"), "https://www.svgrepo.com/show/413691/pay.svg", "Salary & Wages", "Income" },
                    { new Guid("a5c9d3e7-f1b2-6c8d-9e0f-323456789013"), "https://www.svgrepo.com/show/405713/fuel-pump.svg", "Fuel & Gas", "Expense" },
                    { new Guid("a8c9d2e6-f7a1-5b0c-7d8e-723456789007"), "https://www.svgrepo.com/show/223958/retirement.svg", "Retirement Pension", "Income" },
                    { new Guid("b4c8d2e6-f7a9-5b8c-9d0e-223456789002"), "https://www.svgrepo.com/show/245451/contract-loan.svg", "Freelance & Contract Work", "Income" },
                    { new Guid("b6d0e4f8-a2b3-7c9d-8e0f-423456789014"), "https://www.svgrepo.com/show/467123/medical-receipt-3.svg", "Medical & Healthcare", "Expense" },
                    { new Guid("b9d0e3f7-a1b2-6c9d-8e0f-823456789008"), "https://www.svgrepo.com/show/425119/cashback-cash-payment.svg", "Cashback & Rewards", "Income" },
                    { new Guid("c0e4f5a6-b2c3-7d9e-9f0a-923456789009"), "https://www.svgrepo.com/show/276247/lottery-bingo.svg", "Lottery Winnings", "Income" },
                    { new Guid("c5d9e3f7-a8b0-6c9d-0e1f-323456789003"), "https://www.svgrepo.com/show/502410/enterprise.svg", "Business Revenue", "Income" },
                    { new Guid("c7e1f5a9-b3c4-8d9e-0f1a-523456789015"), "https://www.svgrepo.com/show/513295/credit-card.svg", "Credit Card Payments", "Expense" },
                    { new Guid("d2e6f0a4-b7c9-3d8e-9f1a-023456789010"), "https://www.svgrepo.com/show/271922/rent-house.svg", "Rent & Mortgage", "Expense" },
                    { new Guid("d5e9f0a4-b7c9-3d8e-9f1a-423456789004"), "https://www.svgrepo.com/show/530179/stock-movement.svg", "Stock Investments", "Income" },
                    { new Guid("d8f2a6b0-c4d5-9e0f-1a2b-623456789016"), "https://www.svgrepo.com/show/259646/streaming-learning.svg", "Education & Subscriptions", "Expense" },
                    { new Guid("e3f7a1b5-c8d0-4e9f-0a2b-123456789011"), "https://www.svgrepo.com/show/530384/food.svg", "Food & Groceries", "Expense" },
                    { new Guid("e6f1a2b5-c8d0-4e9f-0a2b-523456789005"), "https://www.svgrepo.com/show/283137/real-estate-house.svg", "Real Estate Income", "Income" },
                    { new Guid("e9a3b7c1-d5e6-0f2a-3b4c-723456789017"), "https://www.svgrepo.com/show/261492/clothing.svg", "Clothing & Shopping", "Expense" },
                    { new Guid("f0b4c8d2-e6a7-1f3a-4b5c-823456789018"), "https://www.svgrepo.com/show/502425/entertainment.svg", "Entertainment", "Expense" },
                    { new Guid("f4a8b9c2-d1e3-5f6a-7c0d-223456789012"), "https://www.svgrepo.com/show/513278/bus.svg", "Transportation", "Expense" },
                    { new Guid("f7a3b4c8-d2e6-5f9a-6b0c-623456789006"), "https://www.svgrepo.com/show/484569/coin.svg", "Passive Income", "Income" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "DefaultCategories");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
