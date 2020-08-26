using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace EDIS.Models.Identity
{
    public class DepartmentModel
    {
        [Key]
        [Display(Name = "部門代號")]
        public string DptId { get; set; }
        [Display(Name = "中文名稱")]
        public string Name_C { get; set; }
        [Display(Name = "英文名稱")]
        public string Name_E { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "部門信箱")]
        public string Email { get; set; }
        [Display(Name = "地理位置")]
        public string Loc { get; set; }
        [Display(Name = "建立日期")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "最後異動日期")]
        public DateTime? LastActivityDate { get; set; }

        private readonly ApplicationDbContext db;
        public DepartmentModel(ApplicationDbContext context)
        {
            db = context;
        }
        public DepartmentModel()
        {

        }
        /// <summary>
        /// Get User's location by user's department.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GetUserLocation(AppUserModel user)
        {
            string loc = null;
            if (user != null)
            {
                var dpt = db.Departments.Find(user.DptId);
                if (dpt != null)
                {
                    loc = dpt.Loc;
                    if (loc == "K" || loc == "P" || loc == "C") //  總院代號
                    {
                        loc = "總院";
                    }
                }
            }
            return loc;
        }
    }
}
