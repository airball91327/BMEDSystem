using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDIS.Models
{
    public partial class KeepFlowModel
    {
        [Key, Column(Order = 1)]
        public string DocId { get; set; }
        [Key, Column(Order = 2)]
        [Display(Name = "關卡號")]
        public int StepId { get; set; }
        [Display(Name = "關卡")]
        public string Cls { get; set; }
        [Display(Name = "意見描述")]
        public string Opinions { get; set; }
        public DateTime? Rdt { get; set; }
        [Display(Name = "角色")]
        public string Role { get; set; }
        [Display(Name = "異動人員")]
        public int? Rtp { get; set; }
        [Display(Name = "異動時間")]
        public DateTime Rtt { get; set; }
        [Display(Name = "狀態")]
        public string Status { get; set; }
        [Display(Name = "關卡人員")]
        public int UserId { get; set; }
        [NotMapped]
        public string UserName { get; set; }
        [NotMapped]
        [Display(Name = "廠商")]
        public string Vendor { get; set; }
        [NotMapped]
        [Display(Name = "關卡流程提示")]
        public string FlowHint { get; set; }
    }
}
