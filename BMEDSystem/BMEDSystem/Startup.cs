using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDIS.Areas.BMED.Repositories;
using EDIS.Areas.FORMS.Data;
using EDIS.Extensions;
using EDIS.Fliters;
using EDIS.Models;
using EDIS.Models.Identity;
using EDIS.Repositories;
using EDIS.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EDIS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EdisConnection")));//AzureConnection//EdisConnection//LOCALConnection
            //new
            services.AddDbContext<BMEDDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EdisConnection")));//AzureConnection//EdisConnection//LOCALConnection

            services.AddScoped<IRepository<AppUserModel, int>, AppUserRepository>();
            services.AddScoped<IRepository<DepartmentModel, string>, DepartmentRepository>();
            services.AddScoped<IRepository<DocIdStore, string[]>, DocIdStoreRepository>();
            services.AddScoped<IRepository<AppRoleModel, int>, AppRoleRepository>();

            services.AddScoped<IRepository<RepairModel, string>, BMEDRepairRepository>();
            services.AddScoped<IRepository<RepairDtlModel, string>, BMEDRepairDtlRepository>();
            services.AddScoped<IRepository<RepairFlowModel, string[]>, BMEDRepairFlowRepository>();
            services.AddScoped<IRepository<RepairEmpModel, string[]>, BMEDRepairEmpRepository>();

            services.Configure<SecurityStampValidatorOptions>(options => options.ValidationInterval = TimeSpan.FromHours(10));
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddEntityFrameworkStores<BMEDDBContext>() //new
                .AddRoleStore<ApplicationRole>()
                .AddUserStore<ApplicationUser>()
                .AddDefaultTokenProviders()
                .AddUserManager<CustomUserManager>()
                .AddRoleManager<CustomRoleManager>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "Asp.Net.Core.Identity.BMED_System";//更改BMED_System
                options.ExpireTimeSpan = TimeSpan.FromHours(2);
                options.SlidingExpiration = true;   //動態更新Cookie的過期時間，超過50%自動更新，無設定時預設值為true
            });

            //
            services.AddScoped<UserManager<ApplicationUser>, CustomUserManager>();
            services.AddScoped<RoleManager<ApplicationRole>, CustomRoleManager>();
            services.AddScoped<CustomSignInManager>();
            // 
            services.AddTransient<IUserStore<ApplicationUser>, CustomUserStore>();
            services.AddTransient<IRoleStore<ApplicationRole>, CustomRoleStore>();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            //services.AddMvc();
            services.AddMvc(options =>
            {
                options.Filters.Add<MyErrorHandlerFilter>();
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseVirtualDirectory("Files", @"D:\Files");
            app.UseVirtualDirectory("Files/BMED", @"D:\Files\BMED");
            app.UseStaticFiles();
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(), "Files")),
            //    RequestPath = "/Files"
            //});

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "areas",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
