using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDIS.Models
{
    public partial class DeliveryModel
    {
        [Key]
        [Display(Name = "表單編號")]
        public string DocId { get; set; }
        [Display(Name = "申請人代號")]
        public int UserId { get; set; }
        [Display(Name = "申請人姓名")]
        public string UserName { get; set; }
        [Display(Name = "所屬單位")]
        public string Company { get; set; }
        [Display(Name = "聯絡方式")]
        public string Contact { get; set; }
        [Display(Name = "成本中心")]
        public string AccDpt { get; set; }
        [NotMapped]
        public string AccDptNam { get; set; }
        [Display(Name = "申請日期")]
        public DateTime? ApplyDate { get; set; }
        [Display(Name = "合約號碼")]
        public string ContractNo { get; set; }
        [Display(Name = "採購評估案號")]
        public string PurchaseNo { get; set; }
        [Display(Name = "列管編號")]
        public string CrlItemNo { get; set; }
        [Display(Name = "製造號碼")]
        public string MakeNo { get; set; }
        [Display(Name = "交貨人")]
        public string DelivPson { get; set; }
        [NotMapped]
        [Display(Name = "交貨人姓名")]
        public string DelivPsonNam { get; set; }
        [Required]
        [Display(Name = "實際交期")]
        public DateTime DelivDateR { get; set; }
        [Required]
        [Display(Name = "採購人員")]
        public int? PurchaserId { get; set; }
        [NotMapped]
        public string PurchaserName { get; set; }
        [Display(Name = "得標廠商")]
        public string VendorId { get; set; }
        [Display(Name = "廠商名稱")]
        [NotMapped]
        public string VendorNam { get; set; }
        [NotMapped]
        public string UserDpt { get; set; }
        [Required(ErrorMessage = "設備工程師為必填欄位")]
        [Display(Name = "設備工程師")]
        public int EngId { get; set; }
        [NotMapped]
        public string EngName { get; set; }
        [Display(Name = "保固金")]
        public int? WartyNt { get; set; }
        [Display(Name = "收取日")]
        public DateTime? AcceptDate { get; set; }
        [Display(Name = "保固起始日")]
        public DateTime? WartySt { get; set; }
        [Display(Name = "保固終止日")]
        public DateTime? WartyEd { get; set; }
        [Display(Name = "保固月數")]
        public int WartyMon { get; set; }
        [Display(Name = "檔案驗證日")]
        public DateTime? FileTestDate { get; set; }
        [Display(Name = "驗證者")]
        public int? TestUid { get; set; }
        [Display(Name = "規格驗證日")]
        public DateTime? StandardDate { get; set; }
        [Display(Name = "備註說明")]
        public string Memo { get; set; }
        [Display(Name = "報備種類")]
        public string Stype2 { get; set; }
        [Display(Name = "申報設備代碼")]
        public string Code { get; set; }
        [Display(Name = "出廠日期")]
        public DateTime? RelDate { get; set; }
        [Display(Name = "購置日期")]
        public DateTime? OrderDate { get; set; }
        [Display(Name = "設備啟用日")]
        public DateTime? OpenDate { get; set; }
        [NotMapped]
        [Display(Name = "預算編號")]
        public string BudgetId { get; set; }
    }

    public class DelivDataVModel
    {
        public string DocId { get; set; }
        [Display(Name = "保固金")]
        public Nullable<int> WartyNt { get; set; }
        [Display(Name = "收取日")]
        public DateTime? AcceptDate { get; set; }
        [Display(Name = "保固起始日")]
        public DateTime? WartySt { get; set; }
        [Display(Name = "保固終止日")]
        public DateTime? WartyEd { get; set; }
        [Display(Name = "工時")]
        public decimal? Hours { get; set; }
        [Display(Name = "費用")]
        public decimal? Cost { get; set; }
        [Display(Name = "保養方式")]
        public string InOut { get; set; }
        [Display(Name = "保養週期")]
        public Nullable<int> Cycle { get; set; }
        [Display(Name = "起始年月")]
        public Nullable<int> KeepYm { get; set; }
        [Display(Name = "檔案驗證日")]
        public DateTime? FileTestDate { get; set; }
        [Display(Name = "驗證者")]
        public Nullable<int> TestUid { get; set; }
        public List<AssetKeepModel> ak { get; set; }
        [Display(Name = "報備種類")]
        public string Stype2 { get; set; }
        [Display(Name = "申報設備代碼")]
        public string Code { get; set; }
        [Display(Name = "出廠日期")]
        public DateTime? RelDate { get; set; }
        [Display(Name = "購置日期")]
        public DateTime? OrderDate { get; set; }
        [Display(Name = "設備啟用日")]
        public DateTime? OpenDate { get; set; }

    }
}
