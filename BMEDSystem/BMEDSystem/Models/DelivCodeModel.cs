using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDIS.Models
{
    public partial class DelivCodeModel
    {
        [Key]
        [Display(Name = "申報設備代碼")]
        [Required]
        public string Code { get; set; }
        [Display(Name = "描述")]
        [Required]
        public string DSC { get; set; }
        [Display(Name = "異動人員")]
        public int? Rtp { get; set; }
        [Display(Name = "更新時間")]
        public DateTime? Rtt { get; set; }
    }
}
