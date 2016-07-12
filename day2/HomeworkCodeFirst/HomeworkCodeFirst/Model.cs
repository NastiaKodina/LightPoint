namespace HomeworkCodeFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model")
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(e => e.Cart)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderItem>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderItem>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.OrderItem)
                .WillCascadeOnDelete(false);
        }
    }
}
