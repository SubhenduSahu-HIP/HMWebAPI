using HM_Admin.Models;
using Microsoft.EntityFrameworkCore;


using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace HM_Admin
{
    public class HMAdminDBContext : DbContext
    {
        public HMAdminDBContext(DbContextOptions<HMAdminDBContext> options) : base(options)
        {

        }
        public DbSet<AdminUser> AdminUser { get; set; }
        public DbSet<HotelDetails> HotelDetail { get; set; }
        public DbSet<BranchHotelDetails> BranchHotelDetail { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Countries> Country { get; set; }
        public DbSet<States> State { get; set; }
        public DbSet<Cities> City { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUser>()
                .Property(e => e.UserId)
                .UseIdentityColumn(seed: 10, increment: 1);
            modelBuilder.Entity<AdminUser>(
                entity =>
                {
                    entity.Property(e => e.FirstName).IsRequired().HasMaxLength(255);
                    entity.Property(e => e.LastName).IsRequired().HasMaxLength(255);
                    entity.HasIndex(e => e.Email).IsUnique();
                    entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                    entity.Property(e => e.Mobile).IsRequired().HasMaxLength(10);
                    entity.Property(e => e.Password).IsRequired().HasMaxLength(255);
                    entity.Property(e => e.Role).IsRequired().HasMaxLength(255);
                    entity.Property(e => e.IsAdmin).IsRequired().HasDefaultValue(false);
                    entity.Property(e => e.CreatedBy).IsRequired().HasMaxLength(255);
                    entity.Property(e => e.CreatedDate).IsRequired();
                    entity.Property(e => e.ModifiedBy).IsRequired();
                    entity.Property(e => e.ModifiedDate).IsRequired();

                }
            );
            modelBuilder.Entity<HotelDetails>(

                entity =>
                {
                    entity.Property(e => e.HotelRegistrationNumber).IsRequired();
                    entity.HasIndex(e => e.HotelRegistrationNumber).IsUnique();
                }
            );
            modelBuilder.Entity<BranchHotelDetails>()
                .HasOne(e => e.HotelDetail)
                .WithMany(e => e.BranchHotelDetail)
                .HasForeignKey(e => e.HotelId);

            modelBuilder.Entity<Countries>(
                entity =>
                {
                    entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
                    entity.Property(e => e.Code).IsRequired().HasMaxLength(10);
                    entity.HasIndex(e => e.Code).IsUnique();
                    entity.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);                    
                }
            );
            modelBuilder.Entity<States>(
                entity =>
                {
                    entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
                    entity.Property(e => e.StateCode).IsRequired().HasMaxLength(10);
                    entity.HasIndex(e => e.StateCode).IsUnique();
                    entity.HasOne(e => e.Country)
                          .WithMany(c => c.State)
                          .HasForeignKey(e => e.CountryId)
                          .OnDelete(DeleteBehavior.Cascade);
                }
            );
            modelBuilder.Entity<Cities>(
                entity =>
                {
                    entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
                    entity.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);
                    entity.Property(e => e.StateId).IsRequired();
                    entity.HasOne(e => e.State)
                          .WithMany(s => s.City)
                          .HasForeignKey(e => e.StateId)
                          .OnDelete(DeleteBehavior.Cascade);
                }
            );

        }
    }
}
