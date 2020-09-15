using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDIS.Models
{
    public class EngsInDptsViewModel
    {
        [Display(Name = "部門名稱")]
        public string DptName { get; set; }
        [Display(Name = "部門代號")]
        public string DptId { get; set; }
        [Display(Name = "工程師ID")]
        public int EngId { get; set; }
        [Display(Name = "負責工程師")]
        public string EngName { get; set; }
        [Display(Name = "工程師代號")]
        public string EngUserName { get; set; }
        [Display(Name = "異動人員")]
        public string RtpName { get; set; }
        [Display(Name = "異動時間")]
        public DateTime? Rtt { get; set; }

        public AppUserModel AppUsers { get; set; }
    }
}
