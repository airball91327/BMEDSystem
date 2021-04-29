using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDIS.Models
{
    public partial class VendorModel
    {
        [Key]
        [Display(Name = "廠商編號")]
        public int VendorId { get; set; }
        [Required]
        [Display(Name = "廠商名稱")]
        public string VendorName { get; set; }
        [Display(Name = "地址")]
        public string Address { get; set; }
        [Display(Name = "聯絡電話")]
        public string Tel { get; set; }
        [Display(Name = "傳真")]
        public string Fax { get; set; }
        [Display(Name = "電子郵件")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "統一編號")]
        public string UniteNo { get; set; }
        [Display(Name = "稅籍地址")]
        public string TaxAddress { get; set; }
        [Display(Name = "稅籍地址區號")]
        public string TaxZipCode { get; set; }
        [Display(Name = "聯絡人姓名")]
        public string Contact { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "聯絡人電話")]
        public string ContactTel { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "聯絡人Email")]
        public string ContactEmail { get; set; }
        [Display(Name = "開始日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "結束日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "狀態")]
        public string Status { get; set; }
        [Display(Name = "類別")]
        public string Kind { get; set; }
    }

    public class QryVendor
    {
        [Display(Name = "查詢方式")]
        public string QryType { get; set; }
        [Display(Name = "關鍵字")]
        public string KeyWord { get; set; }
        [Display(Name = "統一編號")]
        public string UniteNo { get; set; }
        [Display(Name = "廠商")]
        public string Vno { get; set; }
        [Display(Name = "廠商列表")]
        public IEnumerable<SelectListItem> VendorList { get; set; }
    }
}
