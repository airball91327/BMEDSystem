using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDIS.Areas.FORMS.Models
{
    public class OutsideBmedListModel
    {
        [Display(Name = "表單類別")]
        public string DocType { get; set; }
        [Display(Name = "表單編號")]
        public string DocId { get; set; }
        [Display(Name = "申請人")]
        public string UserName { get; set; }
        [Display(Name = "申請人編號")]
        public string UserId { get; set; }
        [Display(Name = "說明")]
        public string Topic { get; set; }
        [Display(Name = "申請日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime ApplyDate { get; set; }
       
        [Display(Name = "到達時間")]
        public DateTime Rtt { get; set; }
        [Display(Name = "文件狀態")]
        public string Status { get; set; }
        [Display(Name = "流程類別")]
        public string Kind { get; set; }

       
        [Display(Name = "使用開始日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime UseDayFrom { get; set; }
        
        [Display(Name = "使用結束日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime UseDayTo { get; set; }

        
        [Display(Name = "使用部門")]
        public string UseUnit { get; set; }
        
        [Display(Name = "品名")]
        public string Name { get; set; }
        
        [Display(Name = "型號")]
        public string Model { get; set; }
        
        [Display(Name = "序號")]
        public string Serial { get; set; }
        
        [Display(Name = "廠牌")]
        public string Label { get; set; }

        [Display(Name = "關卡人員")]
        public string Cls { get; set; }

    }
}