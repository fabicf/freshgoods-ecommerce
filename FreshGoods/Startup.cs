using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FreshGoods.Data;
using Microsoft.EntityFrameworkCore;
using FreshGoods.Models;
using Microsoft.AspNetCore.Identity;

namespace FreshGoods
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
            services.AddRazorPages();
            services.AddSession();
            services.AddDbContext<FreshGoodsDbContext>();
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<FreshGoodsDbContext>();
            services.Configure<IdentityOptions>(options =>
                {
                    // Password settings.
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 8;
                    options.Password.RequiredUniqueChars = 5;

                    // Lockout settings.
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;

                    // User settings.
                    options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = true;
                    // allow users with EmailConfirmed value 0/false to log in
                    options.SignIn.RequireConfirmedAccount = false;
                });
                
                services.ConfigureApplicationCookie(options =>
                    {
                    // Cookie settings
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(25);

                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/AccessDenied";
                    options.SlidingExpiration = true;
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            SeedUsersAndRoles(userManager, roleManager);
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
        private void SeedUsersAndRoles(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) {
            // note: we only seed roles in this particular example but
            // you may want to seed users with assigned roles too (e.g. an Administrator user)
            string[] roleNamesList = new string[] { "User", "Admin", "Worker" };

            foreach (string roleName in roleNamesList)
            {
                if (!roleManager.RoleExistsAsync(roleName).Result) {
                    IdentityRole role = new IdentityRole();
                    role.Name = roleName;
                    IdentityResult result = roleManager.CreateAsync(role).Result;
                    // WARNING: we ignore any errors that Create may return, they should be AT LEAST logged !
                    foreach (IdentityError error in result.Errors) {
                        // TODO: Log it!
                    }
                }
            }
            // WARNING: For testing ONLY. Do NOT do it on a production system!
            // Create an Administrator. 
            string adminEmail = "admin@admin.com";
            string adminPass = "Admin123!"; 
            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = adminEmail;
                user.Email = adminEmail;
                user.EmailConfirmed = true;
                user.Address1="11200, Bouleward de pierrefonds";
                user.Address2 ="Pierrefonds";
                user.City ="Montreal";
                user.Province ="Quebec";
                user.ZipCode ="H9A 3X5";
                IdentityResult result = userManager.CreateAsync(user, adminPass).Result;
                if (result.Succeeded)
                {
                    IdentityResult result2 = userManager.AddToRoleAsync(user, "Admin").Result;
                    if (!result2.Succeeded) {
                        // FIXME: log the error
                    }
                } else {
                    // FIXME: log the error
                }
            }
        }
    }
}
