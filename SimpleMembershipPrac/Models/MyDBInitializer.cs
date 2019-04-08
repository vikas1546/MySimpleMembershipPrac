using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;

namespace SimpleMembershipPrac.Models
{
    public class MyDBInitializer : DropCreateDatabaseIfModelChanges<MyAppDbContext>
    {
        //The seed method is called immediately after a new, empty database is created.
        //Seed method is never called for an existing database.
        //protected override void Seed(MyAppDbContext context)
        //{
        //    InitializeWebSecurity();
        //    InitializeDB(context);

        //    base.Seed(context);

        //}
        internal new void Seed(MyAppDbContext context)   // note the new keyword
        {
            InitializeWebSecurity();
            InitializeDB(context);

            base.Seed(context);
        }


        private static void InitializeWebSecurity()
        {
            // we removed this below line from here. and initialised websecurity in global.asax.
          //  WebSecurity.InitializeDatabaseConnection("mycon", "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (!roles.RoleExists("Customer"))
            {
                roles.CreateRole("Customer");
            }
            if (!roles.RoleExists("Accounts"))
            {
                roles.CreateRole("Accounts");
            }

            if (membership.GetUser("test", false) == null)
            {
                membership.CreateUserAndAccount("test", "123456");
            }
            if (membership.GetUser("test1", false) == null)
            {
                membership.CreateUserAndAccount("test1", "123456");
            }

            if (!roles.GetRolesForUser("test").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "test" }, new[] { "admin" });
            }
            if (!roles.GetRolesForUser("test1").Contains("Customer"))
            {
                roles.AddUsersToRoles(new[] { "test1" }, new[] { "Customer" });
            }
        }

        private  void InitializeDB(MyAppDbContext context)
        {
            IList<Category> category = new List<Category>();
            category.Add(new Category { CategoryName = "Action" });
            category.Add(new Category { CategoryName = "Thrill" });
            foreach (Category item in category)
            {
                context.Category.Add(item);
            }

            context.SaveChanges();

          ///  base.Seed(context);
           
        }

       
    }
}