using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ArtRoyalDetailing.Models;

#nullable disable

namespace ArtRoyalDetailing.DatabaseContext
{
    public partial class ardContext : DbContext
    {
        public ardContext()
        {
        }

        public ardContext(DbContextOptions<ardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClientsRequest> ClientsRequests { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<ContractStatus> ContractStatuses { get; set; }
        public virtual DbSet<ContractsService> ContractsServices { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceType> ServiceTypes { get; set; }
        public virtual DbSet<ServicesCost> ServicesCosts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkersSheduler> WorkersShedulers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=ard", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<ClientsRequest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("clients_requests");

                entity.HasIndex(e => e.IdService, "fk_requests_services");

                entity.HasIndex(e => e.IdClient, "fk_requests_users");

                entity.Property(e => e.AutoClass)
                    .HasColumnType("text")
                    .HasColumnName("auto_class");

                entity.Property(e => e.AutoModel)
                    .HasMaxLength(70)
                    .HasColumnName("auto_model")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.DateRequest)
                    .HasColumnType("date")
                    .HasColumnName("date_request");

                entity.Property(e => e.IdClient).HasColumnName("id_client");

                entity.Property(e => e.IdService).HasColumnName("id_service");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("fk_requests_users");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdService)
                    .HasConstraintName("fk_requests_services");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasKey(e => e.IdContract)
                    .HasName("PRIMARY");

                entity.ToTable("contracts");

                entity.HasIndex(e => e.IdAdmin, "fk_contractadmin_users");

                entity.HasIndex(e => e.StatusContract, "fk_contracts_status");

                entity.HasIndex(e => e.IdWasher, "fk_contractwasher_users");

                entity.HasIndex(e => e.PaymentType, "fk_payment_type");

                entity.Property(e => e.IdContract).HasColumnName("id_contract");

                entity.Property(e => e.AutoClass)
                    .HasColumnType("text")
                    .HasColumnName("auto_class");

                entity.Property(e => e.AutoModel)
                    .HasMaxLength(100)
                    .HasColumnName("auto_model")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ClientName)
                    .HasMaxLength(255)
                    .HasColumnName("client_name")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.DateContract)
                    .HasColumnType("date")
                    .HasColumnName("date_contract");

                entity.Property(e => e.EndCost).HasColumnName("end_cost");

                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");

                entity.Property(e => e.IdWasher).HasColumnName("id_washer");

                entity.Property(e => e.PaymentType).HasColumnName("payment_type");

                entity.Property(e => e.StatusContract).HasColumnName("status_contract");

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.ContractIdAdminNavigations)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("fk_contractadmin_users");

                entity.HasOne(d => d.IdWasherNavigation)
                    .WithMany(p => p.ContractIdWasherNavigations)
                    .HasForeignKey(d => d.IdWasher)
                    .HasConstraintName("fk_contractwasher_users");

                entity.HasOne(d => d.PaymentTypeNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.PaymentType)
                    .HasConstraintName("fk_payment_type");

                entity.HasOne(d => d.StatusContractNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.StatusContract)
                    .HasConstraintName("fk_contracts_status");
            });

            modelBuilder.Entity<ContractStatus>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PRIMARY");

                entity.ToTable("contract_statuses");

                entity.Property(e => e.IdStatus).HasColumnName("id_status");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(40)
                    .HasColumnName("status_name")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<ContractsService>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("contracts_services");

                entity.HasIndex(e => e.IdContract, "fk_contracts");

                entity.HasIndex(e => e.IdService, "fk_services");

                entity.Property(e => e.IdContract).HasColumnName("id_contract");

                entity.Property(e => e.IdService).HasColumnName("id_service");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdContract)
                    .HasConstraintName("fk_contracts");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdService)
                    .HasConstraintName("fk_services");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("PRIMARY");

                entity.ToTable("payment_types");

                entity.Property(e => e.IdType).HasColumnName("id_type");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(40)
                    .HasColumnName("type_name")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .HasColumnName("role_name")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.IdService)
                    .HasName("PRIMARY");

                entity.ToTable("services");

                entity.HasIndex(e => e.ServiceType, "ser_type_idx");

                entity.Property(e => e.IdService).HasColumnName("id_service");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(255)
                    .HasColumnName("service_name")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ServiceType).HasColumnName("service_type");

                entity.HasOne(d => d.ServiceTypeNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.ServiceType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ser_type");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("PRIMARY");

                entity.ToTable("service_type");

                entity.Property(e => e.IdType).HasColumnName("id_type");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("type_name");
            });

            modelBuilder.Entity<ServicesCost>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("services_costs");

                entity.HasIndex(e => e.IdService, "fk_costs_services");

                entity.Property(e => e.ClassAuto)
                    .HasMaxLength(50)
                    .HasColumnName("class_auto");

                entity.Property(e => e.Cost)
                    .HasMaxLength(50)
                    .HasColumnName("cost");

                entity.Property(e => e.IdService).HasColumnName("id_service");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdService)
                    .HasConstraintName("fk_costs_services");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.UserRole, "fk_users_roles");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserLogin)
                    .HasMaxLength(45)
                    .HasColumnName("user_login");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("user_name")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(45)
                    .HasColumnName("user_password");

                entity.Property(e => e.UserPhonenumber)
                    .HasMaxLength(18)
                    .HasColumnName("user_phonenumber")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.UserRole).HasColumnName("user_role");

                entity.Property(e => e.UserSurname)
                    .HasMaxLength(50)
                    .HasColumnName("user_surname")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.HasOne(d => d.UserRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRole)
                    .HasConstraintName("fk_users_roles");
            });

            modelBuilder.Entity<WorkersSheduler>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("workers_sheduler");

                entity.HasIndex(e => e.IdWorker, "fk_work_shed_users_idx");

                entity.Property(e => e.DateDay)
                    .HasColumnType("date")
                    .HasColumnName("date_day");

                entity.Property(e => e.IdWorker).HasColumnName("id_worker");

                entity.Property(e => e.TimeStart)
                    .HasColumnType("datetime")
                    .HasColumnName("time_start");

                entity.Property(e => e.TimeStop)
                    .HasColumnType("datetime")
                    .HasColumnName("time_stop");

                entity.HasOne(d => d.IdWorkerNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdWorker)
                    .HasConstraintName("fk_work_shed_users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
