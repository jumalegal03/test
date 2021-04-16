using AKDEMIC.ENTITIES.Models.Generals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TST.CORE.Helpers;
using TST.ENTITIES.Models.Generals;

namespace TST.REPOSITORY.Data
{
    public class TstContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TstContext(DbContextOptions<TstContext> options) : base(options)
        {
            _httpContextAccessor = new HttpContextAccessor();

            Database.SetCommandTimeout(Int32.MaxValue);
        }
        public TstContext(DbContextOptions<TstContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;

            Database.SetCommandTimeout(Int32.MaxValue);
        }

        #region TABLES

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Product>(x => x.ToTable("Products"));
            modelBuilder.Entity<Category>(x => x.ToTable("Categories"));
        }

    }
}
