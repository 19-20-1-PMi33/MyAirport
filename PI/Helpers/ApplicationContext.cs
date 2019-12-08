namespace PI.Helpers
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;
    using System.Windows;
    using PI.Models;
    using System.IO;
    /// <summary>
    /// Клас ApplicationContext створений для роботи з базою даних.
    /// Наслідується від DbContext.
    ///  DbContext визначає контекст данних, використовуваних для взаємодії з базою данних.
    /// </summary>
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("name=ConnectionToDB")
        {
            DirectoryInfo networkDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string twoLevelsUp = networkDir.Parent.Parent.Parent.FullName + "\\Database";
            AppDomain.CurrentDomain.SetData(
  "DataDirectory", Path.Combine(twoLevelsUp, ""));
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

            modelBuilder.Entity<Airport>()
                .Property(e => e.CIty)
                .IsUnicode(false);

            modelBuilder.Entity<Airport>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Airport>()
                .Property(e => e.IATA)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);


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
