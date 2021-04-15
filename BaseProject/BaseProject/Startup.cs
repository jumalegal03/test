using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AKDEMIC.ENTITIES.Models.Generals;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TST.BaseProject.Extensions;
using TST.ENTITIES.Models.Generals;
using TST.REPOSITORY.Data;

namespace BaseProject
{
    public class Startup
    {
        private readonly IWebHostEnvironment CurrentEnvironment;
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            CurrentEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region DATABASE

            services.AddDbContext<TstContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure()));

            #endregion

            #region IDENTITY

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            })
               .AddEntityFrameworkStores<TstContext>()
               .AddDefaultTokenProviders();

            #endregion

            #region Repositories / Services
            services.AddRepository();
            services.AddTransientServices();
            services.AddMemoryCache();
            #endregion

            #region Auth
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                 .AddCookie(options =>
                 {
                     options.Cookie.IsEssential = true;
                     //options.Cookie.SameSite = SameSiteMode.None;
                 });

            #endregion

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/login";
                options.Cookie.Name = "TSTAUTH";
            });

            if (!CurrentEnvironment.IsDevelopment())
            {
                services.AddControllersWithViews();
            }
            else
            {
                services.AddControllersWithViews().AddRazorRuntimeCompilation();
            }

            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (!env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.Use(async (ctx, next) =>
                {
                    await next();
                    if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
                    {
                        //Re-execute the request so the user gets the error page
                        string originalPath = ctx.Request.Path.Value;
                        ctx.Items["originalPath"] = originalPath;
                        ctx.Request.Path = "/error/404";
                        await next();
                    }
                });

                app.UseExceptionHandler("/error/500");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }

    }
}
