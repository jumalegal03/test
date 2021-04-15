using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

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
            builder.UseSqlServer(
                "Server=localhost;Database=TEST;Trusted_Connection=True;MultipleActiveResultSets=true",
                options =>
                {
                    options.CommandTimeout((int)TimeSpan.FromMinutes(20).TotalSeconds);
                    options.EnableRetryOnFailure();
                }); ;

            return new TstContext(builder.Options);
        }
    }
}
