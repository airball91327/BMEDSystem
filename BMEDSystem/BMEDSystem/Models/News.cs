﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDIS.Models
{
    
        [Table("News")]
        public class News
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "消息序號")]
            public int NewsId { get; set; }
            [Required(ErrorMessage ="必須填寫")]
            [Display(Name = "消息主旨")]
            
            public string NewsTitle { get; set; }
            [Required(ErrorMessage ="必須填寫")]
            [Display(Name = "消息內容")]
            public string NewsContent { get; set; }
            [Required(ErrorMessage ="必須填寫")]
            [Display(Name = "刊登起始日")]
            [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}",
                ApplyFormatInEditMode = true)]
            public DateTime? Sdate { get; set; }
            [Required(ErrorMessage ="必須填寫")]
            [Display(Name = "刊登終止日")]
            [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
            public DateTime? Edate { get; set; }
            [Display(Name = "申請者代號")]
            public int UserId { get; set; }
            [NotMapped]
            [Display(Name = "申請者姓名")]
            public string UserName { get; set; }
            [Display(Name = "狀態")]
            public string Status { get; set; }
            [Display(Name = "異動日期")]
            public DateTime? RTT { get; set; }
        }
    
}
