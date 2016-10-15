using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DataModel.Models;
using DataModel.Migrations;

namespace DataModel
{
    public class Entities : IdentityDbContext<ApplicationUser>
    {
        static Entities()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Entities, Configuration>());
        }

        public Entities() : base("DefaultConnection", throwIfV1Schema: false) {}

        public static Entities Create()
        {
            return new Entities();
        }

        public DbSet<Message> Messages { get; set; }
        public IDbSet<Product> Products { get; set; }
        public DbSet<SystemInfo> SystemInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);           
        }

        //public System.Data.Entity.DbSet<DataModel.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}
