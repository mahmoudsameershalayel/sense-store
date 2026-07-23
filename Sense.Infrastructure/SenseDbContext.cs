using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sense.Domain.DBEntities;
using Sense.Infrastructure.Configurations;
using Sense.Domain.Enums;

namespace Sense.Infrastructure
{
    public class SenseDbContext : IdentityDbContext<ApplicationUserTbl>
    {
        public SenseDbContext(DbContextOptions<SenseDbContext> options)
        : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ConfigureUserCustomerRelationship());
            modelBuilder.Entity<TechSupportTbl>().HasOne(c => c.ApplicationUser).WithOne().HasForeignKey<TechSupportTbl>(c => c.ApplicationUserId);
            modelBuilder.Entity<MaintenanceRecordTbl>().HasOne(c => c.Appointment).WithOne().HasForeignKey<MaintenanceRecordTbl>(c => c.AppointmentId);


            modelBuilder.Entity<MaintenanceRecordTbl>().HasOne(x => x.Supervisor).WithMany(x => x.MaintenanceRecords).HasForeignKey(x => x.SupervisorId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InvoiceTbl>().HasOne(x => x.MaintenanceRecord).WithMany(x => x.Invoices).HasForeignKey(x => x.MaintenanceRecordId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<InvoiceTbl>().HasOne(x => x.Order).WithMany(x => x.Invoices).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApplicationUserTbl>()
                 .HasIndex(u => u.Email)
                 .IsUnique();

            modelBuilder.Entity<ProviderRequestTbl>(entity =>
            {
                entity.Property(request => request.FullName).HasMaxLength(150).IsRequired();
                entity.Property(request => request.BusinessName).HasMaxLength(180).IsRequired();
                entity.Property(request => request.Email).HasMaxLength(256).IsRequired();
                entity.Property(request => request.PhoneNumber).HasMaxLength(25).IsRequired();
                entity.Property(request => request.BusinessDescription).HasMaxLength(3000).IsRequired();
                entity.Property(request => request.DocumentStoredName).HasMaxLength(100).IsRequired();
                entity.Property(request => request.DocumentOriginalName).HasMaxLength(255).IsRequired();
                entity.Property(request => request.DocumentContentType).HasMaxLength(100).IsRequired();
                entity.Property(request => request.InternalNote).HasMaxLength(3000);
                entity.Property(request => request.RejectionReason).HasMaxLength(2000);
                entity.Property(request => request.ReviewedByUserId).HasMaxLength(450);
                entity.Property(request => request.RowVersion).IsRowVersion();

                entity.HasIndex(request => request.Email)
                    .IsUnique()
                    .HasFilter("[Status] = 1 AND [IsDeleted] = 0");
                entity.HasOne(request => request.ApprovedProvider)
                    .WithMany()
                    .HasForeignKey(request => request.ApprovedProviderId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            string ADMIN_ID = "02174cf0-9412-4cfe-afbf-59f706d72cf6";
            string ADMIN_ROLE_ID = "341743f0-9427-42de-afbf-59f706d72cf6";
            string SUPERVISOR_ROLE_ID = "edb2f88e-9a0d-4694-b559-6d5183d869ad";
            string CUSTOMER_ROLE_ID = "341743f0-8ce4-42de-afbf-59f706d72cf6";
            string Technical_Support_ROLE_ID = "456743f7-8ce4-42tg-afbf-59f706d72cf6";
            string PROVIDER_ROLE_ID = "789743f9-8ce4-42de-afbf-59f706d72cf6";
            static DateTime SeedCreatedAt(long ticks) => new DateTime(2026, 1, 1, 11, 54, 20, 608, DateTimeKind.Utc).AddTicks(ticks);

            modelBuilder.Entity<IdentityRole>().HasData(
                 new IdentityRole
                 {
                     Name = "Administrator",
                     NormalizedName = "ADMINISTRATOR",
                     Id = ADMIN_ROLE_ID,
                     ConcurrencyStamp = ADMIN_ROLE_ID
                 }, new IdentityRole
                 {
                     Name = "Customer",
                     NormalizedName = "CUSTOMER",
                     Id = CUSTOMER_ROLE_ID,
                     ConcurrencyStamp = CUSTOMER_ROLE_ID
                 }, new IdentityRole
                 {
                     Name = "Supervisor",
                     NormalizedName = "SUPERVISOR",
                     Id = SUPERVISOR_ROLE_ID,
                     ConcurrencyStamp = SUPERVISOR_ROLE_ID
                 }
                 , new IdentityRole
                 {
                     Name = "TechSupport",
                     NormalizedName = "TECHSUPPORT",
                     Id = Technical_Support_ROLE_ID,
                     ConcurrencyStamp = Technical_Support_ROLE_ID
                 }
                 , new IdentityRole
                 {
                     Name = "Provider",
                     NormalizedName = "PROVIDER",
                     Id = PROVIDER_ROLE_ID,
                     ConcurrencyStamp = PROVIDER_ROLE_ID
                 }
           );


            //create admin user
            var admin = new ApplicationUserTbl
            {
                Id = ADMIN_ID,
                Email = "admin@admin.com",
                EmailConfirmed = true,
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin_10",
                PhoneNumber = "+966501234568",
                NormalizedUserName = "ADMIN_10",
                UserType = UserType.Administrator,
                ConcurrencyStamp = "9523ae04-6e0c-4696-acd0-d641db252997",
                SecurityStamp = "5b280f40-43cb-4281-b8d3-7d91cb00818b",
                PasswordHash = "AQAAAAIAAYagAAAAEG5HI3sbn0vCUEBqaSuRnJooEngMtG7MP2v1SzDpPINNlQOrrf/aB4cvIXfG/vBNww=="
            };
            //seed users
            modelBuilder.Entity<ApplicationUserTbl>().HasData(admin);

            //set user role to admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });

            modelBuilder.Entity<InventoryTbl>()
                .HasOne(i => i.Item)
                .WithMany(p => p.Inventories)
                .HasForeignKey(i => i.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductTbl>().HasOne(x => x.Brand).WithMany(x => x.Products).HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AppointmentTbl>()
                        .HasOne(a => a.Service)
                        .WithMany(s => s.Appointments)
                        .HasForeignKey(a => a.ServiceId)
                        .OnDelete(DeleteBehavior.Restrict); // or your preferred delete behavior
            modelBuilder.Entity<BrandTbl>().HasData(
                new BrandTbl { Id = 1, Name = "Toyota", CreatedAt = SeedCreatedAt(8351) },
                new BrandTbl { Id = 2, Name = "Nissan", CreatedAt = SeedCreatedAt(8364) },
                new BrandTbl { Id = 3, Name = "Mercedes", CreatedAt = SeedCreatedAt(8365) },
                new BrandTbl { Id = 4, Name = "BMW", CreatedAt = SeedCreatedAt(8367) },
                new BrandTbl { Id = 5, Name = "Audi", CreatedAt = SeedCreatedAt(8368) },
                new BrandTbl { Id = 6, Name = "Honda", CreatedAt = SeedCreatedAt(8370) },
                new BrandTbl { Id = 7, Name = "Ford", CreatedAt = SeedCreatedAt(8371) },
                new BrandTbl { Id = 8, Name = "Chevrolet", CreatedAt = SeedCreatedAt(8372) },
                new BrandTbl { Id = 9, Name = "Hyundai", CreatedAt = SeedCreatedAt(8373) },
                new BrandTbl { Id = 10, Name = "Kia", CreatedAt = SeedCreatedAt(8375) },
                new BrandTbl { Id = 11, Name = "Lexus", CreatedAt = SeedCreatedAt(8376) },
                new BrandTbl { Id = 12, Name = "Jeep", CreatedAt = SeedCreatedAt(8384) },
                new BrandTbl { Id = 13, Name = "Mazda", CreatedAt = SeedCreatedAt(8385) },
                new BrandTbl { Id = 14, Name = "Mitsubishi", CreatedAt = SeedCreatedAt(8387) },
                new BrandTbl { Id = 15, Name = "Porsche", CreatedAt = SeedCreatedAt(8388) },
                new BrandTbl { Id = 16, Name = "Rolls Royce", CreatedAt = SeedCreatedAt(8389) },
                new BrandTbl { Id = 17, Name = "Land Rover", CreatedAt = SeedCreatedAt(8391) },
                new BrandTbl { Id = 18, Name = "Suzuki", CreatedAt = SeedCreatedAt(8392) },
                new BrandTbl { Id = 19, Name = "Tesla", CreatedAt = SeedCreatedAt(8393) },
                new BrandTbl { Id = 20, Name = "Dodge", CreatedAt = SeedCreatedAt(8398) }
            );

            modelBuilder.Entity<StatementTbl>().HasData(
                new StatementTbl { Id = 1, Text = "منتجات موثوقة وخدمة تهتم بكل التفاصيل", IconClass = "bx bx-check-shield", SortOrder = 1, CreatedAt = SeedCreatedAt(9001) },
                new StatementTbl { Id = 2, Text = "توصيل سريع وآمن حتى باب منزلك", IconClass = "bx bx-package", SortOrder = 2, CreatedAt = SeedCreatedAt(9002) },
                new StatementTbl { Id = 3, Text = "دفع آمن بوسائل متعددة", IconClass = "bx bx-lock-alt", SortOrder = 3, CreatedAt = SeedCreatedAt(9003) },
                new StatementTbl { Id = 4, Text = "منتجات أصلية من مورّدين موثوقين", IconClass = "bx bx-badge-check", SortOrder = 4, CreatedAt = SeedCreatedAt(9004) },
                new StatementTbl { Id = 5, Text = "دعم متواصل جاهز لمساعدتك في أي وقت", IconClass = "bx bx-headphone", SortOrder = 5, CreatedAt = SeedCreatedAt(9005) },
                new StatementTbl { Id = 6, Text = "تشكيلة متجددة من أحدث المنتجات باستمرار", IconClass = "bx bx-refresh", SortOrder = 6, CreatedAt = SeedCreatedAt(9006) }
            );

            modelBuilder.Entity<ModelTbl>().HasData(
                // Toyota (BrandId = 1)
                new ModelTbl { Id = 2, Name = "Camry", BrandId = 1, CreatedAt = SeedCreatedAt(8470) },
                new ModelTbl { Id = 3, Name = "RAV4", BrandId = 1, CreatedAt = SeedCreatedAt(8473) },

                // Nissan (BrandId = 2)
                new ModelTbl { Id = 4, Name = "Altima", BrandId = 2, CreatedAt = SeedCreatedAt(8474) },
                new ModelTbl { Id = 5, Name = "Sentra", BrandId = 2, CreatedAt = SeedCreatedAt(8476) },

                // Mercedes (BrandId = 3)
                new ModelTbl { Id = 6, Name = "C-Class", BrandId = 3, CreatedAt = SeedCreatedAt(8477) },
                new ModelTbl { Id = 7, Name = "E-Class", BrandId = 3, CreatedAt = SeedCreatedAt(8479) },

                // BMW (BrandId = 4)
                new ModelTbl { Id = 8, Name = "3 Series", BrandId = 4, CreatedAt = SeedCreatedAt(8480) },
                new ModelTbl { Id = 9, Name = "X5", BrandId = 4, CreatedAt = SeedCreatedAt(8486) },

                // Audi (BrandId = 5)
                new ModelTbl { Id = 10, Name = "A4", BrandId = 5, CreatedAt = SeedCreatedAt(8488) },
                new ModelTbl { Id = 11, Name = "Q7", BrandId = 5, CreatedAt = SeedCreatedAt(8489) },

                // Honda (BrandId = 6)
                new ModelTbl { Id = 12, Name = "Civic", BrandId = 6, CreatedAt = SeedCreatedAt(8495) },
                new ModelTbl { Id = 13, Name = "Accord", BrandId = 6, CreatedAt = SeedCreatedAt(8496) },

                // Ford (BrandId = 7)
                new ModelTbl { Id = 14, Name = "Focus", BrandId = 7, CreatedAt = SeedCreatedAt(8498) },
                new ModelTbl { Id = 15, Name = "Explorer", BrandId = 7, CreatedAt = SeedCreatedAt(8499) },

                // Chevrolet (BrandId = 8)
                new ModelTbl { Id = 16, Name = "Malibu", BrandId = 8, CreatedAt = SeedCreatedAt(8500) },
                new ModelTbl { Id = 17, Name = "Tahoe", BrandId = 8, CreatedAt = SeedCreatedAt(8502) },

                // Hyundai (BrandId = 9)
                new ModelTbl { Id = 18, Name = "Elantra", BrandId = 9, CreatedAt = SeedCreatedAt(8503) },
                new ModelTbl { Id = 19, Name = "Tucson", BrandId = 9, CreatedAt = SeedCreatedAt(8505) },

                // Kia (BrandId = 10)
                new ModelTbl { Id = 20, Name = "Sportage", BrandId = 10, CreatedAt = SeedCreatedAt(8506) },
                new ModelTbl { Id = 21, Name = "Sorento", BrandId = 10, CreatedAt = SeedCreatedAt(8507) },

                // Lexus (BrandId = 11)
                new ModelTbl { Id = 22, Name = "RX", BrandId = 11, CreatedAt = SeedCreatedAt(8509) },
                new ModelTbl { Id = 23, Name = "ES", BrandId = 11, CreatedAt = SeedCreatedAt(8510) },

                // Jeep (BrandId = 12)
                new ModelTbl { Id = 24, Name = "Wrangler", BrandId = 12, CreatedAt = SeedCreatedAt(8511) },

                // Mazda (BrandId = 13)
                new ModelTbl { Id = 25, Name = "CX-5", BrandId = 13, CreatedAt = SeedCreatedAt(8513) },

                // Mitsubishi (BrandId = 14)
                new ModelTbl { Id = 26, Name = "Outlander", BrandId = 14, CreatedAt = SeedCreatedAt(8514) },

                // Porsche (BrandId = 15)
                new ModelTbl { Id = 27, Name = "911", BrandId = 15, CreatedAt = SeedCreatedAt(8516) },

                // Rolls Royce (BrandId = 16)
                new ModelTbl { Id = 28, Name = "Phantom", BrandId = 16, CreatedAt = SeedCreatedAt(8517) },

                // Land Rover (BrandId = 17)
                new ModelTbl { Id = 29, Name = "Range Rover", BrandId = 17, CreatedAt = SeedCreatedAt(8518) },

                // Suzuki (BrandId = 18)
                new ModelTbl { Id = 30, Name = "Swift", BrandId = 18, CreatedAt = SeedCreatedAt(8519) },

                // Tesla (BrandId = 19)
                new ModelTbl { Id = 31, Name = "Model S", BrandId = 19, CreatedAt = SeedCreatedAt(8521) },
                new ModelTbl { Id = 32, Name = "Model 3", BrandId = 19, CreatedAt = SeedCreatedAt(8522) },

                // Dodge (BrandId = 20)
                new ModelTbl { Id = 33, Name = "Charger", BrandId = 20, CreatedAt = SeedCreatedAt(8523) },
                new ModelTbl { Id = 34, Name = "Durango", BrandId = 20, CreatedAt = SeedCreatedAt(8525) }
            );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppointmentTbl> AppointmentTbls { get; set; }
        public DbSet<AddressTbl> AddressTbls { get; set; }
        public DbSet<BranchTbl> BranchTbls { get; set; }
        public DbSet<BannerTbl> BannerTbls { get; set; }
        public DbSet<BrandTbl> BrandTbls { get; set; }
        public DbSet<ModelTbl> ModelTbls { get; set; }
        public DbSet<CustomerTbl> CustomerTbls { get; set; }
        public DbSet<CategoryTbl> CategoryTbls { get; set; }
        public DbSet<CartItemTbl> CartItemTbls { get; set; }
        public DbSet<CashbackOfferTbl> CashbackOfferTbls { get; set; }
        public DbSet<CashbackOfferUsageTbl> CashbackOfferUsageTbls { get; set; }
        public DbSet<CouponTbl> CouponTbls { get; set; }
        public DbSet<StatementTbl> StatementTbls { get; set; }
        public DbSet<CouponUsageTbl> CouponUsageTbls { get; set; }
        public DbSet<ContactFormTbl> ContactFormTbls { get; set; }
        public DbSet<ConnectionTbl> ConnectionTbls { get; set; }
        public DbSet<ChatMessageTbl> ChatMessageTbls { get; set; }
        public DbSet<FreeMaintenanceOfferTbl> FreeMaintenanceOfferTbls { get; set; }
        public DbSet<FreeMaintenanceEligibilityTbl> FreeMaintenanceEligibilityTbls { get; set; }
        public DbSet<InvoiceTbl> InvoiceTbls { get; set; }
        public DbSet<MaintenanceRecordTbl> MaintenanceRecordTbls { get; set; }
        public DbSet<OrderTbl> OrderTbls { get; set; }
        public DbSet<OrderDetailsTbl> OrderDetailsTbls { get; set; }
        public DbSet<ProductTbl> ProductTbls { get; set; }
        public DbSet<ProviderTbl> ProviderTbls { get; set; }
        public DbSet<ProviderRequestTbl> ProviderRequestTbls { get; set; }
        public DbSet<PhoneVerificationTbl> PhoneVerificationTbls { get; set; }
        public DbSet<ShoppingCartTbl> ShoppingCartTbls { get; set; }
        public DbSet<ServiceTbl> ServiceTbls { get; set; }
        public DbSet<TransactionTbl> TransactionTbls { get; set; }
        public DbSet<PointsTransactionTbl> PointsTransactionTbls { get; set; }
        public DbSet<WalletTbl> WalletTbls { get; set; }
        public DbSet<MarketingCampaignTbl> MarketingCampaignTbls { get; set; }
        public DbSet<TechSupportTbl> TechSupportTbls { get; set; }
        public DbSet<ChatSessionTbl> ChatSessionTbls { get; set; }
        public DbSet<CenterSettingTbl> centerSettingTbls { get; set; }
        public DbSet<InventoryTbl> InventoryTbls { get; set; }
        public DbSet<SupervisorActivityLog> SupervisorActivityLogTbls { get; set; }
        public DbSet<CustomerActivityLog> CustomerActivityLogTbls { get; set; }
        public DbSet<Otp> Otps { get; set; }
    }
}
