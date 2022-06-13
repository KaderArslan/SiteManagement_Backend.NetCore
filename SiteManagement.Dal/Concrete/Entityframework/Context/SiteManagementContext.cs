using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using SiteManagement.Entity.Models;

#nullable disable

namespace SiteManagement.Dal.Concrete.Entityframework.Context
{
    public partial class SiteManagementContext : DbContext
    {
        IConfiguration configuration;
        public SiteManagementContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //public SiteManagementContext(DbContextOptions<SiteManagementContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NIRVANA;Database=SiteManagement;Trusted_Connection=True;");
            }

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.AdminCarStatus)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AdminEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminPhoneNum)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminSurname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminTcnum)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AdminTCNum")
                    .IsFixedLength(true);

                entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admin_Apartment");
            });

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.ToTable("Apartment");

                entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");

                entity.Property(e => e.ApartmentBlock)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ApartmentEndDate).HasColumnType("datetime");

                entity.Property(e => e.ApartmentStartDate).HasColumnType("datetime");

                entity.Property(e => e.ApartmentType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("Bill");

                entity.Property(e => e.BillId).HasColumnName("BillID");

                //entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");

                entity.Property(e => e.BillDate).HasColumnType("datetime");

                //entity.Property(e => e.BillEndDate).HasColumnType("datetime");

                entity.Property(e => e.BillSum).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.BillType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                //entity.HasOne(d => d.Admin)
                //    .WithMany(p => p.Bills)
                //    .HasForeignKey(d => d.AdminId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Bill_Admin");

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bill_Apartment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bill_User");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.MessageDate).HasColumnType("datetime");

                entity.Property(e => e.MessageText)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.MessageTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.MessageReceiverNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.MessageReceiver)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_User");

                entity.HasOne(d => d.MessageSenderNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.MessageSender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Message_Admin");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ApartmentId).HasColumnName("ApartmentID");

                entity.Property(e => e.UserCarStatus)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserEMail");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhoneNum)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserSurname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserTcnum)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UserTCNum")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Apartment");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
