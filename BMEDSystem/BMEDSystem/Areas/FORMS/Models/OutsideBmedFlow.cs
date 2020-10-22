using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDIS.Areas.FORMS.Models
{
    [Table("OutsideBmedFlow")]
    public class OutsideBmedFlow
    {
        [Key, Column(Order = 1)]
        public string DocId { get; set; }
        [Key, Column(Order = 2)]
        [Display(Name = "關卡號")]
        public int StepId { get; set; }
        [Display(Name = "關卡人員")]
        public int UserId { get; set; }
        public string UserName { get; set; }
       
        [Display(Name = "意見描述")]
        public string Opinion { get; set; }
        [Display(Name = "狀態")]
        public string Status { get; set; }
        [Display(Name = "關卡")]
        public string Cls { get; set; }
        public DateTime? Rdt { get; set; }
        [Display(Name = "異動人員")]
        public int? Rtp { get; set; }
        [Display(Name = "異動日期")]
        public DateTime Rtt { get; set; }

        [Display(Name = "特殊水、電、氣的需求,請提供資料(須會工務部)")]
       
        public bool item1 { get; set; }
        [Display(Name = "為游離輻射設備(須會輻安室)")]
       
        public bool item2 { get; set; }
       
        [Display(Name = "儀器保養表,試用一個月以上,須至醫工部拿取保養貼紙於機器上,並提供保養週期與保養紀錄於醫工存查")]
        public bool item3 { get; set; }
        
        [Display(Name = "電線接頭無破損")]
        public bool item4 { get; set; }
       
        [Display(Name = "電線無破損裸露")]
        public bool item5 { get; set; }
       
        [Display(Name = "機器外觀無破損")]
        public bool item6 { get; set; }
       
        [Display(Name = "檢測無符合上述需求,儀器不可使用")]
        public bool item7 { get; set; }
    }

    public class Assign
    {
        [Display(Name = "表單編號")]
        public string DocId { get; set; }
        //[Display(Name = "流程提示")]
        //public string Hint { get; set; }
        [Required]
        [Display(Name = "簽核選項")]
        public string AssignCls { get; set; }
        [Display(Name = "意見描述")]
        public string AssignOpn { get; set; }
        [Required]
        [Display(Name = "流程關卡")]
        public string FlowCls { get; set; }
        [Display(Name = "廠商")]
        public string FlowVendor { get; set; }
        public string VendorName { get; set; }
        [Required]
        [Display(Name = "關卡人員")]
        public int? FlowUid { get; set; }
        public string ClsNow { get; set; }
        [Display(Name = "允許驗收人結案?")]
        public bool CanClose { get; set; }
        public string AssetNo { get; set; }
       
        [Display(Name = "特殊水、電、氣的需求,請提供資料(須會工務部)")]
        public bool item1 { get; set; }
        [Display(Name = "為游離輻射設備(須會輻安室)")]
        public bool item2 { get; set; }
        [Display(Name = "儀器保養表,試用一個月以上,須至醫工部拿取保養貼紙於機器上,並提供保養週期與保養紀錄於醫工存查")]
        public bool item3 { get; set; }

        [Display(Name = "電線接頭無破損")]
        public bool item4 { get; set; }
        [Display(Name = "電線無破損裸露")]
        public bool item5 { get; set; }
        [Display(Name = "機器外觀無破損")]
        public bool item6 { get; set; }
        [Display(Name = "檢測無符合上述需求,儀器不可使用")]
        public bool item7 { get; set; }
        [Required]
        [Display(Name = "用途說明")]
        public string Application { get; set; }
        [Display(Name = "審核內容")]
        public string Content { get; set; }
    }
}