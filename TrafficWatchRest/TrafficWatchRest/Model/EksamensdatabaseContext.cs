using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrafficWatchRest.Model
{
    public partial class EksamensdatabaseContext : DbContext
    {
        public EksamensdatabaseContext()
        {
        }

        public EksamensdatabaseContext(DbContextOptions<EksamensdatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Alarm> Alarm { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Route> Route { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=razhorkserver.database.windows.net;Initial Catalog=TrafficWatchDatabase;User ID=Razhork;Password=Makinkunkila26");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(1);

                entity.Property(e => e.HouseNr).HasColumnName("house_nr");

                entity.Property(e => e.Road)
                    .HasColumnName("road")
                    .HasMaxLength(1);

                entity.Property(e => e.ZipCode).HasColumnName("zip_code");
            });

            modelBuilder.Entity<Alarm>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Delay).HasColumnName("delay");

                entity.Property(e => e.WakeUp)
                    .HasColumnName("wake_up")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Administrator).HasColumnName("administrator");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressIdArrival).HasColumnName("address_id_arrival");

                entity.Property(e => e.AddressIdDeparture).HasColumnName("address_id_departure");

                entity.HasOne(d => d.AddressIdArrivalNavigation)
                    .WithMany(p => p.RouteAddressIdArrivalNavigation)
                    .HasForeignKey(d => d.AddressIdArrival)
                    .HasConstraintName("FK_Arrival");

                entity.HasOne(d => d.AddressIdDepartureNavigation)
                    .WithMany(p => p.RouteAddressIdDepartureNavigation)
                    .HasForeignKey(d => d.AddressIdDeparture)
                    .HasConstraintName("FK_Departure");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}