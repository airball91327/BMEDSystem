using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDIS.Models
{
    public partial class NeedFileModel
    {
        [Key, Column(Order = 1)]
        [Display(Name = "序號")]
        public int SeqNo { get; set; }
        [Required]
        [Display(Name = "摘要")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "檔案說明")]
        public string FileDes { get; set; }
        [Display(Name = "類型")]
        public string Type { get; set; }
        [Display(Name = "異動人員")]
        public string Rtp { get; set; }
        [NotMapped]
        public string UserName { get; set; }
        [Display(Name = "異動時間")]
        public DateTime? Rtt { get; set; }
    }
}
