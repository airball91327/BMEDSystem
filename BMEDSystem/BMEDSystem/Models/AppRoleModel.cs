using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDIS.Models
{
    public partial class AppRoleModel
    {
        public AppRoleModel()
        {
            UsersInRoles = new HashSet<UsersInRolesModel>();
        }

        public int RoleId { get; set; }
        [Display(Name = "角色名稱")]
        public string Description { get; set; }
        [Display(Name = "描述")]
        public string RoleName { get; set; }

        public ICollection<UsersInRolesModel> UsersInRoles { get; set; }
    }
}
