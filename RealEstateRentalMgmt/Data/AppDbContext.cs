using System.Data;
using Microsoft.EntityFrameworkCore;
using RealEstateRentalMgmt.Models;

namespace RealEstateRentalMgmt.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<RentArea> RentAreas { get; set; }
        //public DbSet<RentType> RentTypes { get; set; }
        //public DbSet<BuildingRentType> BuildingRentTypes { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Transaction> Transactions { get; set; }
        //public DbSet<TransactionType> TransactionTypes { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        //public DbSet<AssignmentBuilding> AssignmentBuildings { get; set; }
        //public DbSet<AssignmentCustomer> AssignmentCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình tên bảng
            modelBuilder.Entity<Building>().ToTable("building");
            modelBuilder.Entity<District>().ToTable("district");
            modelBuilder.Entity<RentArea>().ToTable("rentarea");
            //modelBuilder.Entity<RentType>().ToTable("renttype");
            //modelBuilder.Entity<BuildingRentType>().ToTable("buildingrenttype");
            //modelBuilder.Entity<Customer>().ToTable("customer");
            //modelBuilder.Entity<Transaction>().ToTable("transaction");
            //modelBuilder.Entity<TransactionType>().ToTable("transactiontype");
            //modelBuilder.Entity<User>().ToTable("user");
            //modelBuilder.Entity<Role>().ToTable("role");
            //modelBuilder.Entity<UserRole>().ToTable("userrole");
            //modelBuilder.Entity<AssignmentBuilding>().ToTable("assignmentbuilding");
            //modelBuilder.Entity<AssignmentCustomer>().ToTable("assignmentcustomer");

            // Cấu hình ánh xạ property với cột trong bảng building
            modelBuilder.Entity<Building>()
                .Property(b => b.Name)
                .HasColumnName("name");

            modelBuilder.Entity<Building>()
                .Property(b => b.Street)
                .HasColumnName("street");

            modelBuilder.Entity<Building>()
                .Property(b => b.Ward)
                .HasColumnName("ward");

            modelBuilder.Entity<Building>()
                .Property(b => b.Structure)
                .HasColumnName("structure");

            modelBuilder.Entity<Building>()
                .Property(b => b.NumberOfBasement)
                .HasColumnName("numberofbasement");

            modelBuilder.Entity<Building>()
                .Property(b => b.FloorArea)
                .HasColumnName("floorarea");

            modelBuilder.Entity<Building>()
                .Property(b => b.Direction)
                .HasColumnName("direction");

            modelBuilder.Entity<Building>()
                .Property(b => b.Level)
                .HasColumnName("level");

            modelBuilder.Entity<Building>()
                .Property(b => b.RentPrice)
                .HasColumnName("rentprice");

            modelBuilder.Entity<Building>()
                .Property(b => b.RentPriceDescription)
                .HasColumnName("rentpricedescription");

            modelBuilder.Entity<Building>()
                .Property(b => b.ServiceFee)
                .HasColumnName("servicefee");

            modelBuilder.Entity<Building>()
                .Property(b => b.CarFee)
                .HasColumnName("carfee");

            modelBuilder.Entity<Building>()
                .Property(b => b.MotorbikeFee)
                .HasColumnName("motorbikefee");

            modelBuilder.Entity<Building>()
                .Property(b => b.OvertimeFee)
                .HasColumnName("overtimefee");

            modelBuilder.Entity<Building>()
                .Property(b => b.WaterFee)
                .HasColumnName("waterfee");

            modelBuilder.Entity<Building>()
                .Property(b => b.ElectricityFee)
                .HasColumnName("electricityfee");

            modelBuilder.Entity<Building>()
                .Property(b => b.Deposit)
                .HasColumnName("deposit");

            modelBuilder.Entity<Building>()
                .Property(b => b.Payment)
                .HasColumnName("payment");

            modelBuilder.Entity<Building>()
                .Property(b => b.RentTime)
                .HasColumnName("renttime");

            modelBuilder.Entity<Building>()
                .Property(b => b.DecorationTime)
                .HasColumnName("decorationtime");

            modelBuilder.Entity<Building>()
                .Property(b => b.BrokerageFee)
                .HasColumnName("brokeragefee");

            modelBuilder.Entity<Building>()
                .Property(b => b.Note)
                .HasColumnName("note");

            modelBuilder.Entity<Building>()
                .Property(b => b.LinkOfBuilding)
                .HasColumnName("linkofbuilding");

            modelBuilder.Entity<Building>()
                .Property(b => b.Map)
                .HasColumnName("map");

            modelBuilder.Entity<Building>()
                .Property(b => b.Image)
                .HasColumnName("image");

            modelBuilder.Entity<Building>()
                .Property(b => b.ManagerName)
                .HasColumnName("managername");

            modelBuilder.Entity<Building>()
                .Property(b => b.ManagerPhone)
                .HasColumnName("managerphonenumber");

            modelBuilder.Entity<Building>()
                .Property(b => b.DistrictId)
                .HasColumnName("districtid");

            // Cấu hình ánh xạ property với cột trong bảng district
            modelBuilder.Entity<District>()
                .Property(d => d.Id)
                .HasColumnName("id");

            modelBuilder.Entity<District>()
                .Property(d => d.Code)
                .HasColumnName("code");

            modelBuilder.Entity<District>()
                .Property(d => d.Name)
                .HasColumnName("name");

            // Cấu hình ánh xạ property với cột trong bảng rentarea
            modelBuilder.Entity<RentArea>()
                .Property(r => r.Value)
                .HasColumnName("value");

            modelBuilder.Entity<RentArea>()
                .Property(r => r.BuildingId)
                .HasColumnName("buildingid");
        }

        public override int SaveChanges()
        {
            UpdateAuditFields();
            return base.SaveChanges();
        }   

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateAuditFields()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = "System";
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedDate = DateTime.Now;
                    entry.Entity.ModifiedBy = "System";
                }
            }
        }
    }
}