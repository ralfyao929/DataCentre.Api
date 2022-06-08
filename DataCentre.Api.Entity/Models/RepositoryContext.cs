using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Entity.Models
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<LoginData> LoginDatas { get; set; }
        public DbSet<UserPrivilege> UserPrivileges { get; set; }
        public DbSet<APILog> APILogs { get; set; }
        public DbSet<PrivilegeData> PrivilegeDatas { get; set; }

        //TO-DO add Model DbSet here...
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<LoginData>().HasNoKey();
            builder.Entity<UserPrivilege>().HasKey(table => new { table.PrivilegeGroup, table.PrivilegeId });
            builder.Entity<PrivilegeData>().HasKey(table => new { table.Id });
            base.OnModelCreating(builder);
        }
    }
}
