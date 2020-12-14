using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDIS.Areas.FORMS.Models;
using EDIS.Models;

namespace EDIS.Areas.FORMS.Data
{
    public partial class BMEDDBContext : DbContext
    {
        public BMEDDBContext()
        { 
        
        }
        public BMEDDBContext(DbContextOptions<BMEDDBContext> options)
           : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        //
        public virtual DbSet<AppUserModel> AppUsers { get; set; }
        public virtual DbSet<AttainFile> AttainFiles { get; set; }
        public virtual DbSet<Instrument> Instruments { get; set; }
        public virtual DbSet<OutsideBmedFlow> OutsideBmedFlows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Entity<Instrument>().ToTable("Instrument");

            modelBuilder.Entity<Instrument>(entity =>
            {
                entity.HasKey(e => e.DocId);
                entity.ToTable("Instrument");
                entity.Property(e => e.DocId).HasMaxLength(128);
                entity.Property(e => e.UserId).IsRequired()
                 .HasMaxLength(50)
                 .IsUnicode(false);
                entity.Property(e => e.UserName).IsRequired()
                 .HasMaxLength(20)
                 .IsUnicode(false);
                entity.Property(e => e.Ext).IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);
                entity.Property(e => e.ToUserId).IsRequired()
                 .HasMaxLength(20)
                 .IsUnicode(false);
                entity.Property(e => e.ToUserName).IsRequired()
                 .HasMaxLength(20)
                 .IsUnicode(false);
                entity.Property(e => e.UseUnit).IsRequired()
                 .HasMaxLength(20)
                 .IsUnicode(false);
                entity.Property(e => e.Name).IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entity.Property(e => e.Model).IsRequired()
                 .HasMaxLength(128)
                 .IsUnicode(false);
                entity.Property(e => e.Serial).IsRequired()
                 .HasMaxLength(128)
                 .IsUnicode(false);
                entity.Property(e => e.Label).IsRequired()
                 .HasMaxLength(50)
                 .IsUnicode(false);
                entity.Property(e => e.Vendor)
                 .HasMaxLength(20)
                 .IsUnicode(false);
                entity.Property(e => e.Phone)
                 .HasMaxLength(20)
                 .IsUnicode(false);
                entity.Property(e => e.Personnel)
                .HasMaxLength(20)
                 .IsUnicode(false);
                entity.Property(e => e.ProjectId)
                .HasMaxLength(20)
                 .IsUnicode(false);
                entity.Property(e => e.IRB_NO)
                .HasMaxLength(50)
                 .IsUnicode(false);
                entity.Property(e => e.TrialHost)
                .HasMaxLength(20)
                 .IsUnicode(false);
                entity.Property(e => e.Application).IsRequired()
                .HasMaxLength(128)
                 .IsUnicode(false);
                entity.Property(e => e.Description).IsRequired()
                .HasMaxLength(128)
                 .IsUnicode(false);
                entity.Property(e => e.Content)
                 .HasMaxLength(20)
                 .IsUnicode(false);
                entity.Property(e => e.UseDayFrom).HasColumnType("datetime");
                entity.Property(e => e.UseDayTo).HasColumnType("datetime");
                entity.Property(e => e.Day).IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
                entity.Property(e => e.ApplyDate).IsRequired();

            });

            modelBuilder.Entity<AttainFile>(entity =>
            {
                entity.HasKey(e => new { e.DocType, e.DocId, e.SeqNo });

                entity.ToTable("BMEDAttainFiles");

                entity.Property(e => e.DocType).HasMaxLength(50);

                entity.Property(e => e.DocId).HasMaxLength(50);

                //entity.Property(e => e.AssetNo).HasMaxLength(50);

                entity.Property(e => e.FileLink).IsRequired();

                entity.Property(e => e.IsPublic).HasMaxLength(50);

                entity.Property(e => e.Rtt).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OutsideBmedFlow>(entity =>
            {
                entity.HasKey(e => new { e.DocId, e.StepId });

                entity.ToTable("OutsideBmedFlow");

                entity.Property(e => e.DocId).HasMaxLength(255);

                entity.Property(e => e.StepId).HasMaxLength(255);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.UserName).HasMaxLength(20);

                entity.Property(e => e.Opinion).HasMaxLength(128);

                entity.Property(e => e.Cls).HasMaxLength(50);

                entity.Property(e => e.Rdt).HasColumnType("datetime");

                entity.Property(e => e.Rtp).HasMaxLength(10);

                entity.Property(e => e.Rtt).HasColumnType("datetime");

                entity.Property(e => e.item1).HasColumnType("bool");

                entity.Property(e => e.item2).HasColumnType("bool");

                entity.Property(e => e.item3).HasColumnType("bool");

                entity.Property(e => e.item4).HasColumnType("bool");

                entity.Property(e => e.item5).HasColumnType("bool");

                entity.Property(e => e.item6).HasColumnType("bool");

                entity.Property(e => e.item7).HasColumnType("bool");


            });

            modelBuilder.Entity<EngsInAssetsModel>(entity =>
            {
                entity.HasKey(e => new { e.EngId, e.AssetNo });

                entity.ToTable("BMEDEngsInAssets");

                entity.Property(e => e.AssetNo).HasMaxLength(50);

                entity.Property(e => e.Rtt).HasColumnType("datetime");

                entity.Property(e => e.UserName).IsRequired();

                entity.HasOne(d => d.Assets)
                    .WithMany(p => p.BMEDEngsInAssets)
                    .HasForeignKey(d => d.AssetNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BMEDEngsInAssets_BMEDAssets");

                entity.HasOne(d => d.Eng)
                    .WithMany(p => p.BMEDEngsInAssets)
                    .HasForeignKey(d => d.EngId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BMEDEngsInAssets_AppUsers");
            });

            modelBuilder.Entity<EngsInDptsModel>(entity =>
            {
                entity.HasKey(e => new { e.AccDptId, e.EngId });

                entity.ToTable("BMEDEngsInDpts");

                entity.Property(e => e.AccDptId).HasMaxLength(50);

                entity.Property(e => e.Rtt).HasColumnType("datetime");

                entity.Property(e => e.UserName).IsRequired();

                entity.HasOne(d => d.AppUsers)
                    .WithMany(p => p.BMEDEngsInDpts)
                    .HasForeignKey(d => d.EngId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BMEDEngsInDpts_AppUsers");
            });

            modelBuilder.Entity<UsersInRolesModel>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.AppRoles)
                    .WithMany(p => p.UsersInRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersInRoles_AppRoles");

                entity.HasOne(d => d.AppUsers)
                    .WithMany(p => p.UsersInRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersInRoles_AppUsers");
            });

            modelBuilder.Entity<AppRoleModel>(entity =>
            {
                entity.ToTable("AppRoles");

                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleName).IsRequired();
            });
        }
    }

    
  }
