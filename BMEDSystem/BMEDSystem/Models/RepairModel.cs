﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDIS.Models
{
    public partial class RepairModel
    {
        [Key]
        [Required]
        [Display(Name = "表單編號")]
        public string DocId { get; set; }
        [Required]
        [Display(Name = "成本中心")]
        public string AccDpt { get; set; }
        [NotMapped]
        public string AccDptName { get; set; }
        [Display(Name = "申請日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime ApplyDate { get; set; }
        [Required(ErrorMessage = "必填寫欄位")]
        [Display(Name = "儀器名稱")]
        public string AssetName { get; set; }
        [Required(ErrorMessage = "必填寫欄位")]
        [Display(Name = "財產編號")]
        public string AssetNo { get; set; }
        [Required]
        [Display(Name = "所屬部門")]
        public string DptId { get; set; }
        [NotMapped]
        public string DptName { get; set; }
        [Required]
        [Display(Name = "負責工程師")]
        public int EngId { get; set; }
        [Required(ErrorMessage = "必填寫欄位")]
        [Display(Name = "分機")]
        public string Ext { get; set; }
        [Display(Name = "MVPN")]
        public string Mvpn { get; set; }
        [Required(ErrorMessage = "必填寫欄位")]
        [Display(Name = "維修別")]
        public string RepType { get; set; }
        [Required(ErrorMessage = "必填寫欄位")]
        [Display(Name = "故障描述")]
        public string TroubleDes { get; set; }
        [Display(Name = "申請人代號")]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "申請人姓名")]
        public string UserName { get; set; }
        [NotMapped]
        [Display(Name = "申請人帳號")]
        public string UserAccount { get; set; }
        [Required]
        [Display(Name = "驗收人代號")]
        public int CheckerId { get; set; }
        [NotMapped]
        [Display(Name = "結案驗收人")]
        public string CheckerName { get; set; }
        [Required(ErrorMessage = "必填寫欄位")]
        [Display(Name = "擺設地點")] //放置地點
        public string PlaceLoc { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "請輸入大於0的數字")]
        [Display(Name = "數量")]
        public int Amt { get; set; }
        [Display(Name = "送修儀器配件")]
        public string PlantDoc { get; set; }
        [Required(ErrorMessage = "必填寫欄位")]
        [Display(Name = "設備類別")]
        public string PlantClass { get; set; }
        [Display(Name = "銷貨單號")]
        public string SalesDocId { get; set; }
        [Display(Name = "設備查詢碼")]
        public string QryKeyName { get; set; }
        [Display(Name = "申請院區")]
        public string Loc { get; set; }
        [Display(Name = "請購申請")]
        public string IsPurchased { get; set; }
        [NotMapped]
        public string EngName { get; set; }
        [NotMapped]
        [Display(Name = "指定工程師")]
        public int? PrimaryEngId { get; set; }
        [NotMapped]
        [Display(Name = "立帳日")]
        public string AssetAccDate { get; set; }
        [NotMapped]
        [Display(Name = "[是][否]為統包")]
        public string NotInExceptDevice { get; set; }
        [NotMapped]
        [Display(Name = "費用")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Cost { get; set; }
    }
}
