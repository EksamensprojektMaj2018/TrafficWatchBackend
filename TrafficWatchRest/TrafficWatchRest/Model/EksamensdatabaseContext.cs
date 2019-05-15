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
        public virtual DbSet<AddressCustomer> AddressCustomer { get; set; }
        public virtual DbSet<Alarm> Alarm { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAlarm> CustomerAlarm { get; set; }
        public virtual DbSet<Route> Route { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=skoleservertest.database.windows.net;Initial Catalog=eksamensdatabase;User ID=PowerTurtleDK;Password=TrafficDB1");
//            }
//        }

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

            modelBuilder.Entity<AddressCustomer>(entity =>
            {
                entity.HasKey(e => new { e.AddressId, e.CustomerId })
                    .HasName("PK__AddressC__86741B706CF78FE4");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.AddressCustomer)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AddressCustomer");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AddressCustomer)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerAddress");
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

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.Administrator).HasColumnName("administrator");

                entity.Property(e => e.AlarmId).HasColumnName("alarm_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(1);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(1);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(1);

                entity.Property(e => e.RouteId).HasColumnName("route_id");
            });

            modelBuilder.Entity<CustomerAlarm>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.AlarmId })
                    .HasName("PK__Customer__4524F294B696762E");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.AlarmId).HasColumnName("alarm_id");

                entity.HasOne(d => d.Alarm)
                    .WithMany(p => p.CustomerAlarm)
                    .HasForeignKey(d => d.AlarmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerAlarm");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerAlarm)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlarmCustomer");
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