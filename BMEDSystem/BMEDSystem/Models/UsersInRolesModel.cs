using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDIS.Models
{
    public partial class UsersInRolesModel
    {
        [Key, Column(Order = 1)]
        public int UserId { get; set; }
        [Key, Column(Order = 2)]
        public int RoleId { get; set; }
        public string UserName { get; set; }

        public AppRoleModel AppRoles { get; set; }
        public AppUserModel AppUsers { get; set; }
    }
}
