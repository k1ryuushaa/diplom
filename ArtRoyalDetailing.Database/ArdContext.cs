using System;
using ArtRoyalDetailing.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pomelo.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ArtRoyalDetailing.Database
{
    public partial class ArdContext : DbContext
    {
        public ArdContext()
        {
            
        }

        public ArdContext(DbContextOptions<ArdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClientsRequests> ClientsRequests { get; set; }
        public virtual DbSet<ContractStatuses> ContractStatuses { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<ContractsServices> ContractsServices { get; set; }
        public virtual DbSet<PaymentTypes> PaymentTypes { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<ServicesCosts> ServicesCosts { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WorkersSheduler> WorkersSheduler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=ard", x => x.ServerVersion("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientsRequests>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("clients_requests");

                entity.HasIndex(e => e.IdClient)
                    .HasName("fk_requests_users");

                entity.HasIndex(e => e.IdService)
                    .HasName("fk_requests_services");

                entity.Property(e => e.AutoClass)
                    .HasColumnName("auto_class")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.AutoModel)
                    .HasColumnName("auto_model")
                    .HasColumnType("varchar(70)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.DateRequest)
                    .HasColumnName("date_request")
                    .HasColumnType("date");

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

            modelBuilder.Entity<ContractStatuses>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PRIMARY");

                entity.ToTable("contract_statuses");

                entity.Property(e => e.IdStatus).HasColumnName("id_status");

                entity.Property(e => e.StatusName)
                    .HasColumnName("status_name")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<Contracts>(entity =>
            {
                entity.HasKey(e => e.IdContract)
                    .HasName("PRIMARY");

                entity.ToTable("contracts");

                entity.HasIndex(e => e.IdAdmin)
                    .HasName("fk_contractadmin_users");

                entity.HasIndex(e => e.PaymentType)
                    .HasName("fk_payment_type");

                entity.HasIndex(e => e.StatusContract)
                    .HasName("fk_contracts_status");

                entity.Property(e => e.IdContract).HasColumnName("id_contract");

                entity.Property(e => e.AutoClass)
                    .HasColumnName("auto_class")
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.AutoModel)
                    .HasColumnName("auto_model")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.ClientName)
                    .HasColumnName("client_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.DateContract)
                    .HasColumnName("date_contract")
                    .HasColumnType("date");

                entity.Property(e => e.EndCost).HasColumnName("end_cost");

                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");

                entity.Property(e => e.PaymentType).HasColumnName("payment_type");

                entity.Property(e => e.StatusContract).HasColumnName("status_contract");

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("fk_contractadmin_users");

                entity.HasOne(d => d.PaymentTypeNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.PaymentType)
                    .HasConstraintName("fk_payment_type");

                entity.HasOne(d => d.StatusContractNavigation)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.StatusContract)
                    .HasConstraintName("fk_contracts_status");
            });

            modelBuilder.Entity<ContractsServices>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("contracts_services");

                entity.HasIndex(e => e.IdContract)
                    .HasName("fk_contracts");

                entity.HasIndex(e => e.IdService)
                    .HasName("fk_services");

                entity.HasIndex(e => e.IdWasher)
                    .HasName("fk_services_washers_idx");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.IdContract).HasColumnName("id_contract");

                entity.Property(e => e.IdService).HasColumnName("id_service");

                entity.Property(e => e.IdWasher).HasColumnName("id_washer");

                entity.HasOne(d => d.IdContractNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdContract)
                    .HasConstraintName("fk_contracts");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdService)
                    .HasConstraintName("fk_services");

                entity.HasOne(d => d.IdWasherNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdWasher)
                    .HasConstraintName("fk_services_washers");
            });

            modelBuilder.Entity<PaymentTypes>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("PRIMARY");

                entity.ToTable("payment_types");

                entity.Property(e => e.IdType).HasColumnName("id_type");

                entity.Property(e => e.TypeName)
                    .HasColumnName("type_name")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PRIMARY");

                entity.ToTable("roles");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasColumnName("role_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => e.WorkerId)
                    .HasName("PRIMARY");

                entity.ToTable("salary");

                entity.Property(e => e.WorkerId).HasColumnName("worker_id");

                entity.Property(e => e.DateSalary)
                    .HasColumnName("date_salary")
                    .HasColumnType("date");

                entity.Property(e => e.Salary1).HasColumnName("salary");

                entity.HasOne(d => d.Worker)
                    .WithOne(p => p.Salary)
                    .HasForeignKey<Salary>(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pk_fk_worker_salary");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("PRIMARY");

                entity.ToTable("service_type");

                entity.Property(e => e.IdType).HasColumnName("id_type");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnName("type_name")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.IdService)
                    .HasName("PRIMARY");

                entity.ToTable("services");

                entity.HasIndex(e => e.ServiceType)
                    .HasName("ser_type_idx");

                entity.Property(e => e.IdService).HasColumnName("id_service");

                entity.Property(e => e.ServiceName)
                    .HasColumnName("service_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.ServiceType).HasColumnName("service_type");

                entity.HasOne(d => d.ServiceTypeNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.ServiceType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ser_type");
            });

            modelBuilder.Entity<ServicesCosts>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("services_costs");

                entity.HasIndex(e => e.IdService)
                    .HasName("fk_costs_services");

                entity.Property(e => e.ClassAuto)
                    .HasColumnName("class_auto")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IdService).HasColumnName("id_service");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdService)
                    .HasConstraintName("fk_costs_services");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.HasIndex(e => e.UserRole)
                    .HasName("fk_users_roles");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserBalance).HasColumnName("user_balance");

                entity.Property(e => e.UserLogin)
                    .HasColumnName("user_login")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.UserPasswordHash)
                    .HasColumnName("user_password_hash")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserPhonenumber)
                    .HasColumnName("user_phonenumber")
                    .HasColumnType("varchar(18)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.Property(e => e.UserRole).HasColumnName("user_role");

                entity.Property(e => e.UserSurname)
                    .HasColumnName("user_surname")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb3")
                    .HasCollation("utf8mb3_general_ci");

                entity.HasOne(d => d.UserRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRole)
                    .HasConstraintName("fk_users_roles");
            });

            modelBuilder.Entity<WorkersSheduler>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("workers_sheduler");

                entity.HasIndex(e => e.IdWorker)
                    .HasName("fk_work_shed_users_idx");

                entity.Property(e => e.DateDay)
                    .HasColumnName("date_day")
                    .HasColumnType("date");

                entity.Property(e => e.IdWorker).HasColumnName("id_worker");

                entity.Property(e => e.TimeStart)
                    .HasColumnName("time_start")
                    .HasColumnType("time");

                entity.Property(e => e.TimeStop)
                    .HasColumnName("time_stop")
                    .HasColumnType("time");

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
