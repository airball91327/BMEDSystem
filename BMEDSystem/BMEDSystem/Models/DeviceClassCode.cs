using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDIS.Models
{
    public partial class DeviceClassCode
    {
        [Display(Name = "設備分類碼")]
        [Key]
        public string M_code { get; set; }
        [Required(ErrorMessage = "必填寫項目")]
        [Display(Name = "設備分類名稱")]
        public string M_name { get; set; }
    }

    public partial class DeviceSortCode
    {
        [Display(Name = "設備分類碼")]
        [Key]
        [Required(ErrorMessage = "必填寫項目")]
        public string M_code { get; set; }
        [Required(ErrorMessage = "必填寫項目")]
        [Display(Name = "設備分類名稱")]
        public string M_name { get; set; }
        [Display(Name = "狀態")]
        [Required(ErrorMessage = "必填寫項目")]
        public string Status { get; set; }
    }


}
