using Microsoft.EntityFrameworkCore;
using State.Design.Pattern.Business.States;
using State.Design.Pattern.Domain;

namespace State.Design.Pattern.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Order> Order { get; set; } = null!;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Order>()
            .Property(e => e.State)
            .HasConversion(
            s => s.GetType().Name,
            s => GetOrderState(s)
            );
    }

    private static OrderState GetOrderState(string state)
    {
        return state switch
        {
            nameof(DraftState) => new DraftState(),
            nameof(ConfirmedState) => new ConfirmedState(),
            nameof(ProcessState) => new ProcessState(),
            nameof(CanceledState) => new CanceledState(),
            _ => throw new InvalidOperationException("Unknown State")

        };
    }

}
