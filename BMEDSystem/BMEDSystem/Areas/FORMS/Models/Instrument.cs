using EDIS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDIS.Areas.FORMS.Models
{
   
    public class Instrument
    {
        [Key]
        [Required]
        [Display(Name = "表單編號")]
        public string DocId { get; set; }
        [Required]
        [Display(Name = "申請人")]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "申請人名稱")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "關卡人員必填寫欄位")]
        [Display(Name = "關卡人員")]
        public int ToUserId { get; set; }
        
        [Display(Name = "關卡人員名稱")]
        public string ToUserName { get; set; }
        [Required(ErrorMessage = "分機必填寫欄位")]
        [Display(Name = "分機")]
        public string Ext { get; set; }
        [Required(ErrorMessage = "使用部門必填寫欄位")]
        [Display(Name = "使用部門")]
        public string UseUnit { get; set; }
        [Required(ErrorMessage = "品名必填寫欄位")]
        [Display(Name = "品名")]
        public string Name { get; set; }
        [Required(ErrorMessage = "型號必填寫欄位")]
        [Display(Name = "型號")]
        public string Model { get; set; }
        [Required(ErrorMessage = "序號必填寫欄位")]
        [Display(Name = "序號")]
        public string Serial { get; set; }
        [Required(ErrorMessage = "廠牌必填寫欄位")]
        [Display(Name = "廠牌")]
        public string Label { get; set; }
        [Display(Name = "廠商")]
        public string Vendor { get; set; }
        [Display(Name = "廠商電話")]
        public string Phone { get; set; }
        [Display(Name = "使用單位試用人員")]
        public string Personnel { get; set; }
        [Display(Name ="計畫編號")]
        public string ProjectId { get; set; }
        [Display(Name = "IRB_NO")]
        public string IRB_NO { get; set; }
        [Display(Name = "試驗主持人")]
        public string TrialHost { get; set; }
        [Required(ErrorMessage = "用途說明必勾選")]
        [Display(Name="用途說明")]
        public string Application { get; set; }
        [Required(ErrorMessage = "說明必填寫欄位")]
        [Display(Name = "說明")]
        public string Description { get; set; }
        
        [Display(Name = "審核內容")]
        public string Content { get; set; }
        [Required(ErrorMessage = "使用開始日期必填寫欄位")]
        [Display(Name = "使用開始日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UseDayFrom { get; set; }
        [Required(ErrorMessage = "使用結束日期必填寫欄位")]
        [Display(Name = "使用結束日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UseDayTo { get; set; }
        [Required]
        [Display(Name = "使用天數")]
        public string Day { get; set; }

        [Display(Name = "申請日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime ApplyDate { get; set; }

        [NotMapped]
        [Required(ErrorMessage ="關卡為必要選項")]
        [Display(Name = "關卡")]
        public string FlowCls { get; set; }
    }
}