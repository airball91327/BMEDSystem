using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDIS.Models
{
    public class TamperModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "表單單號")]
        public string DocId { get; set; }

        [Display(Name ="類別")]
        public string RepType { get; set; }

        [Display(Name = "異動人員")]
        public string UserName { get; set; }

        [Display(Name = "異動人員名稱")]
        public string FullName { get; set; }

        [Display(Name = "原因")]
        public string Title { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [Display(Name = "異動時間")]
        public DateTime? Rtt { get; set; }
    }
}
