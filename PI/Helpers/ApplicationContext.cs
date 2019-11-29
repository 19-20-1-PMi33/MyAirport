namespace PI.Helpers
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using PI.Models;

    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("name=ConnectionToDB")
        {
        }

        public virtual DbSet<Airplane> Airplane { get; set; }
        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<PersonalInformation> PersonalInformation { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<Airplane>()
                .HasMany(e => e.Flight)
                .WithRequired(e => e.Airplane)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Airport>()
                .Property(e => e.CIty)
                .IsUnicode(false);

            modelBuilder.Entity<Airport>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Airport>()
                .Property(e => e.IATA)
                .IsUnicode(false);

            modelBuilder.Entity<Airport>()
                .HasMany(e => e.Flight)
                .WithRequired(e => e.Airport)
                .HasForeignKey(e => e.ArriveCity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Airport>()
                .HasMany(e => e.Flight1)
                .WithRequired(e => e.Airport1)
                .HasForeignKey(e => e.DepartCity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Payment)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                .Property(e => e.DepartCity)
                .IsUnicode(false);

            modelBuilder.Entity<Flight>()
                .Property(e => e.ArriveCity)
                .IsUnicode(false);

            modelBuilder.Entity<Flight>()
                .Property(e => e.DepartTime)
                .HasPrecision(0);

            modelBuilder.Entity<Flight>()
                .Property(e => e.ArriveTime)
                .HasPrecision(0);

            modelBuilder.Entity<Flight>()
                .Property(e => e.Airline)
                .IsUnicode(false);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.PersonalInformation)
                .WithRequired(e => e.Flight)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonalInformation>()
                .Property(e => e.SecondName)
                .IsUnicode(false);

            modelBuilder.Entity<PersonalInformation>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<PersonalInformation>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<PersonalInformation>()
                .Property(e => e.Document)
                .IsUnicode(false);

            modelBuilder.Entity<PersonalInformation>()
                .Property(e => e.Seating)
                .IsUnicode(false);

            modelBuilder.Entity<PersonalInformation>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.CardType)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.CardOwner)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Login)
                .IsUnicode(false);
        }
    }
}
