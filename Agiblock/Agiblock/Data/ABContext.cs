using Agiblock.Models;
using System.Data.Entity;
namespace Agiblock.Data
{
    public class ABContext : DbContext
    {
        public ABContext() : base("Knygos")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new CreateDatabaseIfNotExists<ABContext>());
        }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //USER ENTITY
            modelBuilder.Entity<User>().HasMany<Book>(u => u.books).WithRequired(u => u.owner);
            modelBuilder.Entity<User>().HasMany<Reservation>(u => u.reservationsAsOwner);
            modelBuilder.Entity<User>().HasMany<Reservation>(u => u.reservationsAsLoaner);
            modelBuilder.Entity<User>().HasMany<Review>(u => u.reviews);
            modelBuilder.Entity<User>().HasMany<Report>(u => u.reports);
            modelBuilder.Entity<User>().HasMany<Filter>(u => u.filters);

            //BOOK ENTITY
            modelBuilder.Entity<Book>().HasRequired<User>(u => u.owner);
            modelBuilder.Entity<Book>().HasMany<Reservation>(u => u.reservations);
            modelBuilder.Entity<Book>().HasMany<Review>(u => u.reviews);
            modelBuilder.Entity<Book>().HasMany<Report>(u => u.reports);


        }
    }
}