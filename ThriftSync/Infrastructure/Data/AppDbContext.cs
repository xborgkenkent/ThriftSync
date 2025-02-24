namespace ThriftSync.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Domain.Entities;
public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Income> Incomes { get; set; }
    public DbSet<Budget> Budgets { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<DefaultCategory> DefaultCategories { get; set; }

    private static class IconUrls
    {
        public const string Salary = "https://www.svgrepo.com/show/413691/pay.svg";
        public const string Freelance = "https://www.svgrepo.com/show/245451/contract-loan.svg";
        public const string Business = "https://www.svgrepo.com/show/502410/enterprise.svg";
        public const string Stock = "https://www.svgrepo.com/show/530179/stock-movement.svg";
        public const string RealEstate = "https://www.svgrepo.com/show/283137/real-estate-house.svg";
        public const string Passive = "https://www.svgrepo.com/show/484569/coin.svg";
        public const string Retirement = "https://www.svgrepo.com/show/223958/retirement.svg";
        public const string Cashback = "https://www.svgrepo.com/show/425119/cashback-cash-payment.svg";
        public const string Lottery = "https://www.svgrepo.com/show/276247/lottery-bingo.svg";
        public const string Rent = "https://www.svgrepo.com/show/271922/rent-house.svg";
        public const string Food = "https://www.svgrepo.com/show/530384/food.svg";
        public const string Transportation = "https://www.svgrepo.com/show/513278/bus.svg";
        public const string Fuel = "https://www.svgrepo.com/show/405713/fuel-pump.svg";
        public const string Medical = "https://www.svgrepo.com/show/467123/medical-receipt-3.svg";
        public const string CreditCard = "https://www.svgrepo.com/show/513295/credit-card.svg";
        public const string Education = "https://www.svgrepo.com/show/259646/streaming-learning.svg";
        public const string Clothing = "https://www.svgrepo.com/show/261492/clothing.svg";
        public const string Entertainment = "https://www.svgrepo.com/show/502425/entertainment.svg";
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<DefaultCategory>().HasData(
            new DefaultCategory { Id = Guid.Parse("a3b9c1d2-e5f6-4a7b-8c9d-123456789001"), Name = "Salary & Wages", Type = "Income", IconUrl = IconUrls.Salary },
            new DefaultCategory { Id = Guid.Parse("b4c8d2e6-f7a9-5b8c-9d0e-223456789002"), Name = "Freelance & Contract Work", Type = "Income", IconUrl = IconUrls.Freelance },
            new DefaultCategory { Id = Guid.Parse("c5d9e3f7-a8b0-6c9d-0e1f-323456789003"), Name = "Business Revenue", Type = "Income", IconUrl = IconUrls.Business },
            new DefaultCategory { Id = Guid.Parse("d5e9f0a4-b7c9-3d8e-9f1a-423456789004"), Name = "Stock Investments", Type = "Income", IconUrl = IconUrls.Stock },
            new DefaultCategory { Id = Guid.Parse("e6f1a2b5-c8d0-4e9f-0a2b-523456789005"), Name = "Real Estate Income", Type = "Income", IconUrl = IconUrls.RealEstate },
            new DefaultCategory { Id = Guid.Parse("f7a3b4c8-d2e6-5f9a-6b0c-623456789006"), Name = "Passive Income", Type = "Income", IconUrl = IconUrls.Passive },
            new DefaultCategory { Id = Guid.Parse("a8c9d2e6-f7a1-5b0c-7d8e-723456789007"), Name = "Retirement Pension", Type = "Income", IconUrl = IconUrls.Retirement },
            new DefaultCategory { Id = Guid.Parse("b9d0e3f7-a1b2-6c9d-8e0f-823456789008"), Name = "Cashback & Rewards", Type = "Income", IconUrl = IconUrls.Cashback },
            new DefaultCategory { Id = Guid.Parse("c0e4f5a6-b2c3-7d9e-9f0a-923456789009"), Name = "Lottery Winnings", Type = "Income", IconUrl = IconUrls.Lottery },
            new DefaultCategory { Id = Guid.Parse("d2e6f0a4-b7c9-3d8e-9f1a-023456789010"), Name = "Rent & Mortgage", Type = "Expense", IconUrl = IconUrls.Rent },
            new DefaultCategory { Id = Guid.Parse("e3f7a1b5-c8d0-4e9f-0a2b-123456789011"), Name = "Food & Groceries", Type = "Expense", IconUrl = IconUrls.Food },
            new DefaultCategory { Id = Guid.Parse("f4a8b9c2-d1e3-5f6a-7c0d-223456789012"), Name = "Transportation", Type = "Expense", IconUrl = IconUrls.Transportation },
            new DefaultCategory { Id = Guid.Parse("a5c9d3e7-f1b2-6c8d-9e0f-323456789013"), Name = "Fuel & Gas", Type = "Expense", IconUrl = IconUrls.Fuel },
            new DefaultCategory { Id = Guid.Parse("b6d0e4f8-a2b3-7c9d-8e0f-423456789014"), Name = "Medical & Healthcare", Type = "Expense", IconUrl = IconUrls.Medical },
            new DefaultCategory { Id = Guid.Parse("c7e1f5a9-b3c4-8d9e-0f1a-523456789015"), Name = "Credit Card Payments", Type = "Expense", IconUrl = IconUrls.CreditCard },
            new DefaultCategory { Id = Guid.Parse("d8f2a6b0-c4d5-9e0f-1a2b-623456789016"), Name = "Education & Subscriptions", Type = "Expense", IconUrl = IconUrls.Education },
            new DefaultCategory { Id = Guid.Parse("e9a3b7c1-d5e6-0f2a-3b4c-723456789017"), Name = "Clothing & Shopping", Type = "Expense", IconUrl = IconUrls.Clothing },
            new DefaultCategory { Id = Guid.Parse("f0b4c8d2-e6a7-1f3a-4b5c-823456789018"), Name = "Entertainment", Type = "Expense", IconUrl = IconUrls.Entertainment }
        );
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}