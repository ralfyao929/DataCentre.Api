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
        public DbSet<LoginData> loginDatas { get; set; }

        //TO-DO add Model DbSet here...
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<LoginData>().HasNoKey();
            base.OnModelCreating(builder);
        }
    }
}
