using AKDEMIC.ENTITIES.Models.Generals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(x =>
            {
                x.Property(r => r.Sex).HasDefaultValue(ConstantHelpers.ENTITIES.USER.SEX.UNSPECIFIED);
            });

            modelBuilder.Entity<ApplicationUserRole>(x =>
            {
                x.HasKey(ur => new { ur.UserId, ur.RoleId });
                x.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
                x.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}
