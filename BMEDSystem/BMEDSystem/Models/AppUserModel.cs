using EDIS.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDIS.Models
{
    public partial class AppUserModel
    {
        public AppUserModel()
        {
            BMEDEngsInAssets = new HashSet<EngsInAssetsModel>();
            BMEDEngsInDpts = new HashSet<EngsInDptsModel>();
            UsersInRoles = new HashSet<UsersInRolesModel>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "必填寫欄位")]
        [Display(Name = "使用者名稱")]
        public string UserName { get; set; }
        [Display(Name = "使用者全名")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "必填寫欄位")]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }
        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "新密碼")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "必填寫欄位")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "電子信箱")]
        public string Email { get; set; }
        [Display(Name = "分機")]
        public string Ext { get; set; }
        [Display(Name = "行動電話")]
        public string Mobile { get; set; }
        [Display(Name = "所屬部門")]
        public string DptId { get; set; }
        [Display(Name = "所屬廠商")]
        public int? VendorId { get; set; }
        [NotMapped]
        public string VendorName { get; set; }
        [Display(Name = "建立時間")]
        public System.DateTime DateCreated { get; set; }
        [Display(Name = "最後修改時間")]
        public System.DateTime? LastActivityDate { get; set; }
        [Required(ErrorMessage = "必填寫欄位")]
        [Display(Name = "狀態")]
        public string Status { get; set; }
        [NotMapped]
        public List<UserInRolesViewModel> InRoles { get; set; }

        public ExternalUsers ExternalUsers { get; set; }
        public ICollection<EngsInAssetsModel> BMEDEngsInAssets { get; set; }
        public ICollection<EngsInDptsModel> BMEDEngsInDpts { get; set; }
        public ICollection<UsersInRolesModel> UsersInRoles { get; set; }
    }
}
