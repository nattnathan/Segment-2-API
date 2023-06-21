using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {
            
        }

        // Table Yang Ingin Dibuat Dari Models
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Booking> Bookings{ get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // entitas unique
            modelBuilder.Entity<Employee>()
                        .HasIndex(e => new
                        {
                            e.Nik,
                            e.Email,
                            e.PhoneNumber
                        }).IsUnique();

            // Create Relation
            // University - Education (One to Many)
            modelBuilder.Entity<University>()
                        .HasMany(university => university.Educations)
                        .WithOne(education => education.University)
                        .HasForeignKey(education => education.UniversityGuid);

            // Education - University (Many to One)
            /*modelBuilder.Entity<Education>()
                    .HasOne(education => education.University)
                    .WithMany(university => university.Educations)
                    .HasForeignKey(education => education.UniversityGuid)
                    .OnDelete(DeleteBehavior.Cascade);*/

            // Education - Employee (One to One)
            modelBuilder.Entity<Education>()
                        .HasOne(education => education.Employee)
                        .WithOne(employee => employee.Education)
                        .HasForeignKey<Education>(education => education.Guid);

            // Employee - Booking (One to Many)
            modelBuilder.Entity<Employee>()
                        .HasMany(employee => employee.Bookings)
                        .WithOne(booking => booking.Employee)
                        .HasForeignKey(booking => booking.EmployeeGuid);

            // Booking - Room (Many to One)
            modelBuilder.Entity<Booking>()
                        .HasOne(booking => booking.Room)
                        .WithMany(room => room.Bookings)
                        .HasForeignKey(room => room.RoomGuid);

            // Room - Booking (One to many)
            /*modelBuilder.Entity<Room>()
                        .HasMany(room => room.Bookings)
                        .WithOne(booking => booking.Room)
                        .HasForeignKey(room => room.RoomGuid);*/

            // Employee - Account (One to One)
            modelBuilder.Entity<Employee>()
                        .HasOne(employee => employee.Account)
                        .WithOne(account => account.Employee)
                        .HasForeignKey<Account>(account => account.Guid);                        

            // Account - AccountRole (One to Many)
            modelBuilder.Entity<Account>()
                        .HasMany(account => account.AccountRoles)
                        .WithOne(accountRole => accountRole.Account)
                        .HasForeignKey(accountRole => accountRole.RoleGuid);

            // AccountRoles - Account (Many to One)
            /*modelBuilder.Entity<AccountRole>()
                        .HasOne(accountRole => accountRole.Account)
                        .WithMany(account => account.AccountRoles)
                        .HasForeignKey(accountRole => accountRole.RoleGuid);*/

            // AccountRoles - Role (Many to One)
            modelBuilder.Entity<AccountRole>()
                        .HasOne(accountRole => accountRole.Role)
                        .WithMany(role => role.AccountRoles)
                        .HasForeignKey(role => role.RoleGuid);

            // Role = AccountRole (One to Many)
            /*modelBuilder.Entity<Role>()
                        .HasMany(role => role.AccountRoles)
                        .WithOne(accountrole => accountrole.Role)
                        .HasForeignKey(role => role.RoleGuid);*/
        }
    }
}
