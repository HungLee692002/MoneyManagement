using Microsoft.EntityFrameworkCore;
using System.IO;

namespace MoneyManagement.Models;

public partial class MoneymanagementContext : DbContext
{
    public MoneymanagementContext()
    {
    }

    public MoneymanagementContext(DbContextOptions<MoneymanagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TransitionHistory> TransitionHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "moneymanagement.db");
        optionsBuilder.UseSqlite("Data Source=" + path);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TransitionHistory>(entity =>
        {
            entity.HasKey(e => e.Hid);

            entity.ToTable("TransitionHistory");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
