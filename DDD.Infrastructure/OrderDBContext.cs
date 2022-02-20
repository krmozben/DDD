using DDD.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure
{
    public class OrderDBContext : DbContext
    {
        public const string default_schema = "ordering";

        public OrderDBContext()
        {

        }

        public OrderDBContext(DbContextOptions<OrderDBContext> options)
        : base(options)
        {
 
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders", default_schema);
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems", default_schema);
            modelBuilder.Entity<OrderItem>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Order>().OwnsOne(o => o.Address);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DDD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            base.OnConfiguring(optionsBuilder);
        }
    }
}

