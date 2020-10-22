using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDIS.Areas.FORMS.Models
{
    [Table("OutsideBmed")]
    public class Instrument
    {
        [Key]
        [Required]
        [Display(Name = "表單編號")]
        public string DocId { get; set; }
        [Required]
        [Display(Name = "申請人")]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "申請人名稱")]
        public string UserName { get; set; }
        
        [Display(Name = "單位主管")]
        public int ToUserId { get; set; }
        
        [Display(Name = "主管名稱")]
        public string ToUserName { get; set; }
        [Required]
        [Display(Name = "使用部門")]
        public string UseUnit { get; set; }
        [Required]
        [Display(Name = "品名")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "型號")]
        public string Model { get; set; }
        [Required]
        [Display(Name = "序號")]
        public string Serial { get; set; }
        [Required]
        [Display(Name = "廠牌")]
        public string Label { get; set; }
        [Display(Name = "廠商")]
        public string Vendor { get; set; }
        [Display(Name = "廠商電話")]
        public string Phone { get; set; }
        [Display(Name = "使用部門試用人員")]
        public string Personnel { get; set; }
        [Display(Name ="計畫編號")]
        public string ProjectId { get; set; }
        [Display(Name = "IRB_NO")]
        public string IRB_NO { get; set; }
        [Display(Name = "試驗主持人")]
        public string TrialHost { get; set; }
        [Required]
        [Display(Name="用途說明")]
        public string Application { get; set; }
        [Required]
        [Display(Name = "說明")]
        public string Description { get; set; }
        
        [Display(Name = "審核內容")]
        public string Content { get; set; }
        [Required]
        [Display(Name = "使用開始日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UseDayFrom { get; set; }
        [Required]
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

    }
}