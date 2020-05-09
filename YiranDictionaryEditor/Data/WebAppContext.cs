using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class WebAppContext : DbContext
    {
        public WebAppContext (DbContextOptions<WebAppContext> options)
            : base(options)
        {
        }

        public DbSet<WebApp.Data.DbConfig> DbConfig {
            get; set;
        }
        public DbSet<DbSchema> DbSchemas {
            get;set;
        }
        public DbSet<DbField> DbFields {
            get;set;
        }
        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<DbSchema>().ToTable("DbSchema");
            builder.Entity<DbField>().ToTable("DbField");
            builder.Entity<DbConfig>().ToTable("DbConfig");
        }
    }
}
