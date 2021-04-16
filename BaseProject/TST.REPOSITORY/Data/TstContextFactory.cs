using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using TST.CORE.Helpers;

namespace TST.REPOSITORY.Data
{
    public class TstContextFactory : IDesignTimeDbContextFactory<TstContext>
    {
        public TstContextFactory()
        {

        }

        public TstContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<TstContext> builder = new DbContextOptionsBuilder<TstContext>();
            builder.UseMySql(
                "Server=localhost;Database=TEST;Uid=root;Pwd=root;AllowLoadLocalInfile=true;Connection Timeout=0;Default Command Timeout=0;",
                options =>
                {
                    
                    options.EnableRetryOnFailure();
                    options.ServerVersion(ConstantHelpers.DATABASES.VERSIONS.MYSQL.VALUES[ConstantHelpers.DATABASES.VERSIONS.MYSQL.V8021], ServerType.MySql);
                }); ;

            return new TstContext(builder.Options);
        }
    }
}
