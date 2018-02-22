using LeadMgmt.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadMgmt.Api.Infrastructure
{
    public class LeadMgmtContext : DbContext
    {
        //private IConfigurationRoot _config; 
        public LeadMgmtContext(DbContextOptions options) : base(options)
        {
            
        }  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
            //optionsBuilder.UseSqlServer(_config["ConnectionString:DefaultConnection"]);
        } 
        public DbSet<Lead> Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LeadEntityTypeConfiguration());
        }
    }

    public interface IMyDataContextFactory
    {
        LeadMgmtContext Create();
    }
    public class MyDataContextFactory : IMyDataContextFactory
    {
        const string ConnectionStringName = "DefaultConnection";
        IConfiguration configuration;
        public MyDataContextFactory(IConfiguration Configuration)
        {
            configuration = Configuration;
        }
        public LeadMgmtContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(
            configuration.GetConnectionString(ConnectionStringName));
            return new LeadMgmtContext(optionsBuilder.Options);
        }
    }
}

