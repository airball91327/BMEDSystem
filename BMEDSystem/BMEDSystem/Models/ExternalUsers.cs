using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDIS.Models
{
    public partial class ExternalUsers
    {
        [Key]
        [ForeignKey("AppUsers")]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "使用者名稱")]
        public string UserName { get; set; }

        public AppUserModel AppUsers { get; set; }
    }
}
