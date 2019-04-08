using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleMembershipPrac.Models
{
    public class MyCustomDBInitializer : IDatabaseInitializer<MyAppDbContext>
    {
        public void InitializeDatabase(MyAppDbContext context)
        {
            if (!context.Database.Exists() || !context.Database.CompatibleWithModel(true))
            {
                context.Database.Delete();
                context.Database.Create();
            }
            context.Database.ExecuteSqlCommand("Custom SQL Command here");


           //if (context.Database.Exists())
            //{
            //    if (!context.Database.CompatibleWithModel(true))
            //    {
            //        context.Database.Delete();
            //    }
            //}
            //context.Database.Create();

        }
    }
}