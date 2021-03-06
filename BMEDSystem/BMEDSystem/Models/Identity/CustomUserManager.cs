﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using EDIS.Extensions;
using EDIS.Models;

namespace EDIS.Models.Identity
{
    public class CustomUserManager : UserManager<ApplicationUser>
    {
        public IUserStore<ApplicationUser> _userStore;
        private readonly ApplicationDbContext _context;
        public CustomUserManager(ApplicationDbContext context, IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators, IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger) 
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _context = context;
            _userStore = store;
        }

        public new Task<ApplicationUser> FindByNameAsync(string userName)
        {
            return _userStore.FindByNameAsync(userName, CancellationToken);
        }

        public override string GetUserName(ClaimsPrincipal principal)
        {
            return base.GetUserName(principal);
        }

        public string GetUserFullName(ClaimsPrincipal principal)
        {
            var userName = principal.FindFirstValue(Options.ClaimsIdentity.UserNameClaimType);
            var userId = _userStore.FindByNameAsync(userName, CancellationToken).Result.Id;
            var userFullName = _context.AppUsers.Find(Convert.ToInt32(userId)).FullName;
            return userFullName;
        }

        public int GetCurrentUserId(ClaimsPrincipal principal)
        {
            var userName = principal.FindFirstValue(Options.ClaimsIdentity.UserNameClaimType);
            var userId = _userStore.FindByNameAsync(userName, CancellationToken).Result.Id;
            return Convert.ToInt32(userId);
        }

        public bool IsInRole(ClaimsPrincipal principal, string roleName)
        {
            var userId = Convert.ToInt32(principal.FindFirstValue(Options.ClaimsIdentity.UserIdClaimType));
            var userRoles = _context.UsersInRoles.Include(ur => ur.AppRoles).Include(ur => ur.AppUsers)
                                                 .Where(u => u.UserId == userId).ToList();
            foreach(var item in userRoles)
            {
                if(item.AppRoles.RoleName == roleName)
                {
                    return true;
                }

            }
            return false;
        }

        public string GetCurrentUserDptId(ClaimsPrincipal principal)
        {
            var userName = principal.FindFirstValue(Options.ClaimsIdentity.UserNameClaimType);
            var userId = _userStore.FindByNameAsync(userName, CancellationToken).Result.Id;
            var dptId = _context.AppUsers.Where(u => u.UserName == userName).FirstOrDefault().DptId;
            return dptId;
        }

        public string GetCurrentUserLocName(ClaimsPrincipal principal)
        {
            string loc = null;
            string locName = "總院人員";
            var userName = principal.FindFirstValue(Options.ClaimsIdentity.UserNameClaimType);
            var user = _context.AppUsers.Where(u => u.UserName == userName).FirstOrDefault();
            if (user != null)
            {
                var dpt = _context.Departments.Find(user.DptId);
                if (dpt != null)
                {
                    loc = dpt.Loc;
                    if (loc == "L") 
                    {
                        locName = "二林院區";
                    }
                    else if (loc == "B")
                    {
                        locName = "員林院區";
                    }
                    else if (loc == "N")
                    {
                        locName = "南投院區";
                    }
                    else if (loc == "U")
                    {
                        locName = "鹿基院區";
                    }
                    else if (loc == "T")
                    {
                        locName = "雲基院區";
                    }
                    else  //總院人員
                    {
                         //Do nothing.
                    }
                }
            }
            return locName;
        }

        public override async Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            if (string.IsNullOrEmpty(user.Id))
            {
                return false;
            }
            int id = Convert.ToInt32(user.Id);
            var ur = await _context.AppUsers.FindAsync(id);
            if (ur != null)
            {
                if (!string.IsNullOrEmpty(ur.Password))
                {
                    return true;
                }
            }
            return false;
        }

        public string ChangePassword(ApplicationUser user, string currentPassword, string newPassword)
        {
            string s = "";
            if (string.IsNullOrEmpty(user.Id))
            {
                s = "錯誤!無此帳號!";
                return s;
            }
            int id = Convert.ToInt32(user.Id);
            var ur = _context.AppUsers.Find(id);
            if (ur != null)
            {
                // user's password encrypt by DES.
                //string DESKey = "84203025";
                //var checkPW = CryptoExtensions.DESEncrypt(currentPassword, DESKey);
                if (ur.Password == currentPassword)
                {
                    //var encryptPW = CryptoExtensions.DESEncrypt(newPassword, DESKey);   // Encrypt and check password.
                    ur.Password = newPassword;
                    _context.Entry(ur).State = EntityState.Modified;
                    _context.SaveChanges();
                    s = "成功";
                    return s;
                }
            }
            s = "錯誤!原密碼輸入不正確!";
            return s;
        }

        public string AddPassword(ApplicationUser user, string newPassword)
        {
            string s = "";
            if (string.IsNullOrEmpty(user.Id))
            {
                s = "錯誤!無此帳號!";
                return s;
            }
            int id = Convert.ToInt32(user.Id);
            var ur = _context.AppUsers.Find(id);
            if (ur != null)
            {
                // user's password encrypt by DES.
                //string DESKey = "84203025";
                //var encryptPW = CryptoExtensions.DESEncrypt(newPassword, DESKey);   // Encrypt and check password.
                ur.Password = newPassword;
                _context.Entry(ur).State = EntityState.Modified;
                _context.SaveChanges();
                s = "成功";
                return s;
            }
            s = "錯誤!設定密碼失敗!";
            return s;
        }

    }
}
