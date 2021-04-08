using System;
//using EDIS.Areas.FORMS.Models;
using EDIS.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EDIS.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppRoleModel> AppRoles { get; set; }
        public virtual DbSet<AppUserModel> AppUsers { get; set; }
        //public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        //public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }

        public virtual DbSet<AssetFileModel> AssetFiles { get; set; }
        public virtual DbSet<AssetKeepModel> BMEDAssetKeeps { get; set; }
        public virtual DbSet<AssetModel> BMEDAssets { get; set; }
        public virtual DbSet<AttainFileModel> BMEDAttainFiles { get; set; }
        public virtual DbSet<BudgetModel> Budgets { get; set; }
        public virtual DbSet<BuyEvaluateModel> BuyEvaluates { get; set; }
        public virtual DbSet<BuyFlowModel> BuyFlows { get; set; }
        public virtual DbSet<BuySFlowModel> BuySFlows { get; set; }
        public virtual DbSet<BuyVendorModel> BuyVendors { get; set; }
        public virtual DbSet<DealStatusModel> BMEDDealStatuses { get; set; }
        public virtual DbSet<DelivCodeModel> DelivCodes { get; set; }
        public virtual DbSet<DeliveryModel> Deliveries { get; set; }
        public virtual DbSet<DelivFlowModel> DelivFlows { get; set; }
        public virtual DbSet<DeptStockModel> BMEDDeptStocks { get; set; }
        public virtual DbSet<DeviceClassCode> BMEDDeviceClassCodes { get; set; }
        public virtual DbSet<EngsInAssetsModel> BMEDEngsInAssets { get; set; }
        public virtual DbSet<EngsInDptsModel> EngsInDpts { get; set; }
        public virtual DbSet<FailFactorModel> BMEDFailFactors { get; set; }
        public virtual DbSet<KeepCostModel> BMEDKeepCosts { get; set; }
        public virtual DbSet<KeepDtlModel> BMEDKeepDtls { get; set; }
        public virtual DbSet<KeepEmpModel> BMEDKeepEmps { get; set; }
        public virtual DbSet<KeepFlowModel> BMEDKeepFlows { get; set; }
        public virtual DbSet<KeepFormatDtlModel> BMEDKeepFormatDtls { get; set; }
        public virtual DbSet<KeepFormatModel> BMEDKeepFormats { get; set; }
        public virtual DbSet<KeepRecordModel> BMEDKeepRecords { get; set; }
        public virtual DbSet<KeepResultModel> BMEDKeepResults { get; set; }
        public virtual DbSet<KeepModel> BMEDKeeps { get; set; }
        public virtual DbSet<NeedFileModel> NeedFiles { get; set; }
        public virtual DbSet<RepairCostModel> BMEDRepairCosts { get; set; }
        public virtual DbSet<RepairDtlModel> BMEDRepairDtls { get; set; }
        public virtual DbSet<RepairEmpModel> BMEDRepairEmps { get; set; }
        public virtual DbSet<RepairFlowModel> BMEDRepairFlows { get; set; }
        public virtual DbSet<RepairModel> BMEDRepairs { get; set; }
        public virtual DbSet<TicketDtlModel> BMEDTicketDtls { get; set; }
        public virtual DbSet<TicketModel> BMEDTickets { get; set; }
        public virtual DbSet<Ticket_seq_tmpModel> BMEDTicket_seq_tmps { get; set; }
        public virtual DbSet<VendorModel> BMEDVendors { get; set; }
        public virtual DbSet<DepartmentModel> Departments { get; set; }
        public virtual DbSet<DocIdStore> DocIdStores { get; set; }
        public virtual DbSet<ExceptDevice> ExceptDevice { get; set; }
        //public virtual DbSet<ExternalUsers> ExternalUsers { get; set; }
        public virtual DbSet<UsersInRolesModel> UsersInRoles { get; set; }  
        //public virtual DbSet<Vendors> Vendors { get; set; }
        public virtual DbQuery<UnSignListVModel> UnSignListVModelQuery { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<QuestionnaireM> QuestionnaireMs { get; set; }
        public virtual DbSet<Questionnaire> Questionnaires { get; set; }
        public virtual DbSet<QuestMain> QuestMains { get; set; }
        public virtual DbSet<QuestAnswer> QuestAnswers { get; set; }
        public virtual DbSet<FailFactor> FailFactors { get; set; }
        public virtual DbSet<DeviceSortCode> BMEDDeviceSortCodes { get; set; }
        public virtual DbSet<TamperModel> BMEDTamper { get; set; }






        // Unable to generate entity type for table 'dbo.BuyEvaluate'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.BuyFlow'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Delivery'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DelivFlow'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UserProfile'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Vendor2'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppRoleModel>(entity =>
            {
                entity.ToTable("AppRoles");

                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleName).IsRequired();
            });


            modelBuilder.Entity<News>((Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<News> entity) =>
            {
                entity.HasKey(e => e.NewsId);

                entity.ToTable("News");

                entity.Property(e => e.Sdate).HasColumnType("datetime");

                entity.Property(e => e.Edate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(10);

               
                entity.Property(e => e.NewsTitle).IsRequired().HasMaxLength(200);

                entity.Property(e => e.NewsContent).IsRequired().HasMaxLength(500); 

                entity.Property(e => e.RTT).HasColumnType("datetime");
            });

            modelBuilder.Entity<AppUserModel>((Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AppUserModel> entity) =>
            {
                entity.ToTable("AppUsers");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Status).IsRequired();

                entity.Property(e => e.UserName).IsRequired();
            });

            //modelBuilder.Entity<AspNetRoleClaims>(entity =>
            //{
            //    entity.HasIndex(e => e.RoleId);

            //    entity.Property(e => e.RoleId).IsRequired();

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetRoleClaims)
            //        .HasForeignKey(d => d.RoleId);
            //});

            //modelBuilder.Entity<AspNetRoles>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedName)
            //        .HasName("RoleNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedName] IS NOT NULL)");

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.Name).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetUserClaims>(entity =>
            //{
            //    entity.HasIndex(e => e.UserId);

            //    entity.Property(e => e.UserId).IsRequired();

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserClaims)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserLogins>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            //    entity.HasIndex(e => e.UserId);

            //    entity.Property(e => e.UserId).IsRequired();

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserLogins)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserRoles>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.RoleId });

            //    entity.HasIndex(e => e.RoleId);

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.RoleId);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUsers>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedEmail)
            //        .HasName("EmailIndex");

            //    entity.HasIndex(e => e.NormalizedUserName)
            //        .HasName("UserNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedUserName] IS NOT NULL)");

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //    entity.Property(e => e.UserName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetUserTokens>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserTokens)
            //        .HasForeignKey(d => d.UserId);
            //});

            modelBuilder.Entity<AssetFileModel>(entity =>
            {
                entity.HasKey(e => new { e.AssetNo, e.SeqNo, e.Fid });

                entity.ToTable("BMEDAssetFiles");

                entity.Property(e => e.AssetNo)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Rtp).HasMaxLength(255);
            });

            modelBuilder.Entity<AssetKeepModel>(entity =>
            {
                entity.HasKey(e => e.AssetNo);

                entity.ToTable("BMEDAssetKeeps");

                entity.Property(e => e.AssetNo)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.ContractNo).HasMaxLength(50);

                entity.Property(e => e.FormatId).HasMaxLength(50);

                entity.Property(e => e.Hours).HasColumnType("decimal(18, 1)");

                entity.Property(e => e.InOut).HasMaxLength(50);

                entity.Property(e => e.Rtt).HasColumnType("datetime");
            });

            modelBuilder.Entity<AssetModel>(entity =>
            {
                entity.HasKey(e => e.AssetNo);

                entity.ToTable("BMEDAssets");

                entity.Property(e => e.AssetNo)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccDate).HasColumnType("datetime");

                entity.Property(e => e.AccDpt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AssetClass)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BmedNo).HasMaxLength(50);

                entity.Property(e => e.Brand).HasMaxLength(255);

                entity.Property(e => e.BuyDate).HasColumnType("datetime");

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Current).HasMaxLength(50);

                entity.Property(e => e.DelivDpt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DelivEmp).HasMaxLength(50);

                entity.Property(e => e.DisposeKind).HasMaxLength(50);

                entity.Property(e => e.Docid).HasMaxLength(50);

                entity.Property(e => e.Ename).HasMaxLength(255);

                entity.Property(e => e.IpAddr).HasMaxLength(50);

                entity.Property(e => e.LeaveSite).HasMaxLength(50);

                entity.Property(e => e.MacAddr).HasMaxLength(50);

                entity.Property(e => e.MakeNo).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.Property(e => e.Origin).HasMaxLength(50);

                entity.Property(e => e.RelDate).HasColumnType("datetime");

                entity.Property(e => e.RiskLvl).HasMaxLength(50);

                entity.Property(e => e.Rtt).HasColumnType("datetime");

                entity.Property(e => e.Shares).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Standard).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);

                entity.Property(e => e.Voltage).HasMaxLength(50);
            });

            modelBuilder.Entity<AttainFileModel>(entity =>
            {
                entity.HasKey(e => new { e.DocType, e.DocId, e.SeqNo });

                entity.ToTable("BMEDAttainFiles");

                entity.Property(e => e.DocType).HasMaxLength(50);

                entity.Property(e => e.DocId).HasMaxLength(50);

                entity.Property(e => e.AssetNo).HasMaxLength(50);

                entity.Property(e => e.FileLink).IsRequired();

                entity.Property(e => e.IsPublic).HasMaxLength(50);

                entity.Property(e => e.Rtt).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BudgetModel>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.ToTable("BMEDBudgets");

                entity.Property(e => e.DocId)
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccDpt).HasMaxLength(255);

                entity.Property(e => e.BuyId).HasMaxLength(255);

                entity.Property(e => e.EngName).HasMaxLength(255);

                entity.Property(e => e.Loc).HasMaxLength(255);

                entity.Property(e => e.PlantName).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Standard).HasMaxLength(255);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Unit).HasMaxLength(255);

                entity.Property(e => e.Year).HasMaxLength(255);
            });

            modelBuilder.Entity<BuyEvaluateModel>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.ToTable("BMEDBuyEvaluates");

                entity.Property(e => e.DocId)
                    .HasMaxLength(255)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccDpt).HasMaxLength(255);

                entity.Property(e => e.BudgetId).HasMaxLength(255);

                entity.Property(e => e.Company).HasMaxLength(255);

                entity.Property(e => e.Contact).HasMaxLength(255);

                entity.Property(e => e.Place).HasMaxLength(255);

                entity.Property(e => e.PlantCnam).HasMaxLength(255);

                entity.Property(e => e.PlantEnam).HasMaxLength(255);

                entity.Property(e => e.PlantType).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Unit).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            modelBuilder.Entity<BuyFlowModel>(entity =>
            {
                entity.HasKey(e => new { e.DocId, e.StepId });

                entity.ToTable("BMEDBuyFlows");

                entity.Property(e => e.DocId).HasMaxLength(255);

                entity.Property(e => e.Cls).HasMaxLength(255);

                entity.Property(e => e.Role).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);
            });

            modelBuilder.Entity<BuySFlowModel>(entity =>
            {
                entity.HasKey(e => new { e.DocId, e.StepId, e.DocSid });

                entity.ToTable("BMEDBuySFlows");

                entity.Property(e => e.DocId).HasMaxLength(255);

                entity.Property(e => e.DocSid).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);
            });

            modelBuilder.Entity<BuyVendorModel>(entity =>
            {
                entity.HasKey(e => new { e.DocId, e.VendorNo });

                entity.ToTable("BMEDBuyVendors");

                entity.Property(e => e.DocId).HasMaxLength(255);

                entity.Property(e => e.VendorNo).HasMaxLength(255);

                entity.Property(e => e.Rtp).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(255);

                entity.Property(e => e.UniteNo).HasMaxLength(255);

                entity.Property(e => e.VendorNam).HasMaxLength(255);
            });

            modelBuilder.Entity<DealStatusModel>(entity =>
            {
                entity.ToTable("BMEDDealStatuses");

                entity.Property(e => e.Flg)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DelivCodeModel>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("BMEDDelivCodes");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.DSC)
                    .IsRequired()
                    .HasColumnName("DSC")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<DeliveryModel>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.ToTable("BMEDDeliveries");

                entity.Property(e => e.DocId)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.AcceptDate).HasColumnType("date");

                entity.Property(e => e.ApplyDate).HasColumnType("smalldatetime");

                entity.Property(e => e.DelivDateR).HasColumnType("smalldatetime");

                entity.Property(e => e.FileTestDate).HasColumnType("date");

                entity.Property(e => e.OpenDate).HasColumnType("date");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.RelDate).HasColumnType("date");

                entity.Property(e => e.StandardDate).HasColumnType("smalldatetime");

                entity.Property(e => e.WartyEd).HasColumnType("date");

                entity.Property(e => e.WartySt).HasColumnType("date");
            });

            modelBuilder.Entity<DelivFlowModel>(entity =>
            {
                entity.HasKey(e => new { e.DocId, e.StepId });

                entity.ToTable("BMEDDelivFlows");

                entity.Property(e => e.DocId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Cls)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rdt).HasColumnType("datetime");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rtt).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DeptStockModel>(entity =>
            {
                entity.HasKey(e => e.StockId);

                entity.ToTable("BMEDDeptStocks");

                entity.Property(e => e.Brand).HasMaxLength(50);

                entity.Property(e => e.CustOrganCustId)
                    .HasColumnName("CustOrgan_CustId")
                    .HasMaxLength(50);

                entity.Property(e => e.Loc).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Rtt).HasColumnType("datetime");

                entity.Property(e => e.Standard).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StockCls).HasMaxLength(50);

                entity.Property(e => e.StockName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StockNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Unite).HasMaxLength(50);
            });

            modelBuilder.Entity<DeviceClassCode>(entity =>
            {
                entity.HasKey(e => e.M_code);

                entity.ToTable("BMEDDeviceClassCodes");

                entity.Property(e => e.M_code)
                    .HasColumnName("M_code")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.M_name)
                    .IsRequired()
                    .HasColumnName("M_name");
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

            modelBuilder.Entity<FailFactorModel>(entity =>
            {
                entity.ToTable("BMEDFailFactors");

                entity.Property(e => e.Flg)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<KeepCostModel>(entity =>
            {
                entity.HasKey(e => new { e.DocId, e.SeqNo });

                entity.ToTable("BMEDKeepCosts");

                entity.Property(e => e.DocId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.AccountDate).HasColumnType("datetime");

                entity.Property(e => e.IsPetty)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PartName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PartNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rtt).HasColumnType("datetime");

                entity.Property(e => e.SignNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Standard)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StockType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TicketDtlNo)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Unite)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.TicketDtl)
                    .WithMany(p => p.BMEDKeepCosts)
                    .HasForeignKey(d => new { d.TicketDtlNo, d.TicketDtlSeqNo })
                    .HasConstraintName("FK_BMEDKeepCosts_TicketDtl");
            });

            modelBuilder.Entity<KeepDtlModel>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.ToTable("BMEDKeepDtls");

                entity.Property(e => e.DocId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CloseDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.NotInExceptDevice)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShutDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<KeepEmpModel>(entity =>
            {
                entity.HasKey(e => new { e.DocId, e.UserId });

                entity.ToTable("BMEDKeepEmps");

                entity.Property(e => e.DocId).HasMaxLength(50);
            });

            modelBuilder.Entity<KeepFlowModel>(entity =>
            {
                entity.HasKey(e => new { e.DocId, e.StepId });

                entity.ToTable("BMEDKeepFlows");

                entity.Property(e => e.Rdt).HasColumnType("datetime");

                entity.Property(e => e.Rtt).HasColumnType("datetime");
            });

            modelBuilder.Entity<KeepFormatDtlModel>(entity =>
            {
                entity.HasKey(e => new { e.FormatId, e.Sno });

                entity.ToTable("BMEDKeepFormatDtls");

                entity.Property(e => e.FormatId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.KeepFormat)
                    .WithMany(p => p.BMEDKeepFormatDtls)
                    .HasForeignKey(d => d.FormatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BMEDKeepFormatDtls_KeepFormat");
            });

            modelBuilder.Entity<KeepFormatModel>(entity =>
            {
                entity.HasKey(e => e.FormatId);

                entity.ToTable("BMEDKeepFormats");

                entity.Property(e => e.FormatId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Rtt).HasColumnType("datetime");
            });

            modelBuilder.Entity<KeepRecordModel>(entity =>
            {
                entity.HasKey(e => new { e.DocId, e.FormatId, e.Sno });

                entity.ToTable("BMEDKeepRecords");

                entity.Property(e => e.DocId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FormatId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KeepResultModel>(entity =>
            {
                entity.ToTable("BMEDKeepResults");

                entity.Property(e => e.Flg).IsRequired();

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<KeepModel>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.ToTable("BMEDKeeps");

                entity.Property(e => e.DocId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccDpt).IsRequired();

                entity.Property(e => e.DptId).IsRequired();

                entity.Property(e => e.Ext).IsRequired();

                entity.Property(e => e.SentDate).HasColumnType("date");

                entity.Property(e => e.UserName).IsRequired();
            });

            modelBuilder.Entity<NeedFileModel>(entity =>
            {
                entity.HasKey(e => e.SeqNo);

                entity.ToTable("BMEDNeedFiles");

                entity.Property(e => e.SeqNo).ValueGeneratedNever();

                entity.Property(e => e.Rtp).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);
            });

            modelBuilder.Entity<RepairCostModel>(entity =>
            {
                entity.HasKey(e => new { e.DocId, e.SeqNo });

                entity.ToTable("BMEDRepairCosts");

                entity.Property(e => e.DocId)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.AccountDate).HasColumnType("datetime");

                entity.Property(e => e.IsPetty)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PartName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PartNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rtt).HasColumnType("datetime");

                entity.Property(e => e.SignNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Standard)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StockType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TicketDtlNo)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Unite)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.TicketDtl)
                    .WithMany(p => p.BMEDRepairCosts)
                    .HasForeignKey(d => new { d.TicketDtlNo, d.TicketDtlSeqNo })
                    .HasConstraintName("FK_BMEDRepairCosts_TicketDtl");
            });

            modelBuilder.Entity<RepairDtlModel>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.ToTable("BMEDRepairDtls");

                entity.Property(e => e.DocId).ValueGeneratedNever();

                entity.Property(e => e.CloseDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.NotInExceptDevice)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShutDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RepairEmpModel>(entity =>
            {
                entity.HasKey(e => new { e.DocId, e.UserId });

                entity.ToTable("BMEDRepairEmps");

                entity.Property(e => e.DocId).HasMaxLength(50);
            });

            modelBuilder.Entity<RepairFlowModel>(entity =>
            {
                entity.HasKey(e => new { e.DocId, e.StepId });

                entity.ToTable("BMEDRepairFlows");

                entity.Property(e => e.Rdt).HasColumnType("datetime");

                entity.Property(e => e.Rtt).HasColumnType("datetime");
            });

            modelBuilder.Entity<RepairModel>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.ToTable("BMEDRepairs");

                entity.Property(e => e.DocId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccDpt).IsRequired();

                entity.Property(e => e.ApplyDate).HasColumnType("date");

                entity.Property(e => e.AssetName).IsRequired();

                entity.Property(e => e.AssetNo).IsRequired();

                entity.Property(e => e.DptId).IsRequired();

                entity.Property(e => e.Ext).IsRequired();

                entity.Property(e => e.PlantClass).IsRequired();

                entity.Property(e => e.RepType).IsRequired();

                entity.Property(e => e.TroubleDes).IsRequired();

                entity.Property(e => e.UserName).IsRequired();
            });

            modelBuilder.Entity<TicketDtlModel>(entity =>
            {
                entity.HasKey(e => new { e.TicketDtlNo, e.SeqNo });

                entity.ToTable("BMEDTicketDtls");

                entity.Property(e => e.TicketDtlNo)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ObjName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TicketNo)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Unite)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.TicketDtls)
                    .HasForeignKey(d => d.TicketNo)
                    .HasConstraintName("FK_BMEDTicketDtls_Ticket");
            });

            modelBuilder.Entity<TicketModel>(entity =>
            {
                entity.HasKey(e => e.TicketNo);

                entity.ToTable("BMEDTickets");

                entity.Property(e => e.TicketNo)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ApplyDate).HasColumnType("datetime");

                entity.Property(e => e.CancelDate).HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TicDate).HasColumnType("datetime");

                entity.Property(e => e.TradeCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VendorName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket_seq_tmpModel>(entity =>
            {
                entity.HasKey(e => e.YYYMM);

                entity.ToTable("BMEDTicket_seq_tmps");

                entity.Property(e => e.YYYMM)
                    .HasColumnName("YYYMM")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.TICKET_SEQ)
                    .HasColumnName("TICKET_SEQ")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VendorModel>(entity =>
            {
                entity.HasKey(e => e.VendorId);

                entity.ToTable("BMEDVendors");

                entity.Property(e => e.VendorId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Contact).HasMaxLength(50);

                entity.Property(e => e.ContactEmail).HasMaxLength(50);

                entity.Property(e => e.ContactTel).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.Kind).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.TaxAddress).HasMaxLength(50);

                entity.Property(e => e.TaxZipCode).HasMaxLength(50);

                entity.Property(e => e.Tel).HasMaxLength(50);

                entity.Property(e => e.UniteNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DepartmentModel>(entity =>
            {
                entity.ToTable("Departments");

                entity.HasKey(e => new { e.DptId });
            });

            modelBuilder.Entity<DocIdStore>(entity =>
            {
                entity.HasKey(e => new { e.DocType, e.DocId });

                entity.Property(e => e.DocType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            

            modelBuilder.Entity<ExceptDevice>(entity =>
            {
                entity.HasKey(e => e.AssetNo);

                entity.Property(e => e.AssetNo)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccDpt).HasMaxLength(450);

                entity.Property(e => e.AccDptName).HasMaxLength(255);

                entity.Property(e => e.AssetName).HasMaxLength(255);

                entity.Property(e => e.Brand).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);
            });

            //modelBuilder.Entity<ExternalUsers>(entity =>
            //{
            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.Password).IsRequired();

            //    entity.Property(e => e.UserName).IsRequired();

            //    entity.HasOne(d => d.AppUsers)
            //        .WithOne(p => p.ExternalUsers)
            //        .HasForeignKey<ExternalUsers>(d => d.Id)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_ExternalUsers_AppUsers");
            //});

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

            modelBuilder.Entity<QuestionnaireM>(entity =>
            {
                entity.HasKey(e => e.VerId);

                entity.ToTable("BMEDQuestionnaireM");

                entity.Property(e => e.Qname).HasMaxLength(50);

                entity.Property(e => e.Memo).HasMaxLength(256);

                entity.Property(e => e.Flg).HasMaxLength(10);

                entity.Property(e => e.Rtp).IsRequired();

                entity.Property(e => e.Rtt).HasColumnType("datetime");

            });

            modelBuilder.Entity<Questionnaire>(entity =>
            {
                entity.HasKey(e => new { e.VerId , e.Qid });

                entity.ToTable("BMEDQuestionnaire");

                entity.Property(e => e.Qtitle).HasMaxLength(50);

                entity.Property(e => e.Typ).HasMaxLength(50);
            });

            modelBuilder.Entity<QuestMain>(entity =>
            {
                entity.HasKey(e => e.Docid);

                entity.ToTable("BMEDQuestMain");

                entity.Property(e => e.YYYYmm).HasMaxLength(20);

                entity.Property(e => e.CustId).HasMaxLength(128);

                entity.Property(e => e.CustNam).HasMaxLength(128);

                entity.Property(e => e.Qtitle).HasMaxLength(128);

                entity.Property(e => e.Rtt).HasColumnType("date");


            });

            modelBuilder.Entity<QuestAnswer>(entity =>
            {
                entity.HasKey(e => new { e.Docid ,e.VerId,e.Qid });

                entity.ToTable("BMEDQuestAnswer");

                entity.Property(e => e.Answer).HasMaxLength(265);
            });

            modelBuilder.Entity<FailFactor>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("FailFactor");

                entity.Property(e => e.Title).HasMaxLength(128);

                entity.Property(e => e.Flg).HasMaxLength(128);
            });

            modelBuilder.Entity<DeviceSortCode>(entity =>
            {
                entity.HasKey(e => e.M_code);

                entity.ToTable("BMEDDeviceSortCodes");

                entity.Property(e => e.M_code)
                    .HasColumnName("M_code")
                    .HasMaxLength(200)
                    .ValueGeneratedNever();

                entity.Property(e => e.M_name)
                    .IsRequired()
                    .HasColumnName("M_name");

                entity.Property(e => e.Status)
                    .HasMaxLength(5)
                    .HasColumnName("Status");
            });

            modelBuilder.Entity<TamperModel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("BMEDTamper");

                entity.Property(e => e.DocId).HasMaxLength(50);

                entity.Property(e => e.RepType).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Rtt).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(50);
            });
        }
    }
}
