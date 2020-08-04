﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDIS.Models
{
    public partial class EngsInDptsModel
    {
        [Key, Column(Order = 1)]
        [Display(Name = "成本中心代號")]
        public string AccDptId { get; set; }
        [Key, Column(Order = 2)]
        [Display(Name = "工程師代號")]
        public int EngId { get; set; }
        [Required]
        [Display(Name = "負責工程師")]
        public string UserName { get; set; }
        [Display(Name = "異動人員")]
        public int? Rtp { get; set; }
        [NotMapped]
        [Display(Name = "異動人員帳號")]
        public string RtpName { get; set; }
        [Display(Name = "異動時間")]
        public DateTime? Rtt { get; set; }

        public AppUserModel AppUsers { get; set; }
    }
}
