using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleMembershipPrac.Models
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext() : base("mycon")
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //    modelBuilder.Configurations.Add(new UserConfiguration());
          modelBuilder.Configurations.Add(new CategoryConfiguration());
            //    modelBuilder.Configurations.Add(new BlogConfiguration());
            //    modelBuilder.Configurations.Add(new CommentConfiguration());

            base.OnModelCreating(modelBuilder);
        }


    }
}