namespace BATZBlog.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<BATZBlog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BATZBlog.Models.ApplicationDbContext";
        }

        protected override void Seed(BATZBlog.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //context.Roles.AddOrUpdate(r => r.Name,
                
            //    new IdentityRole { Name= "Admin"},
            //    new IdentityRole { Name="ContentWriter"},
            //    new IdentityRole { Name="BandMember"},
            //    new IdentityRole { Name="Customer"}
            //    );
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleNames = { "Admin", "BandMember", "Customer" };
            IdentityResult roleResult;
            foreach(var roleName in roleNames)
            {
                if (!RoleManager.RoleExists(roleName))
                {
                    roleResult = RoleManager.Create(new IdentityRole(roleName));
                }
            }
            var UserManager = new UserManager<Models.ApplicationUser>(new UserStore<Models.ApplicationUser>(context));
            UserManager.AddToRole("5b2938a8-6bc9-44f8-a421-83e146fdb152", "Admin");
            UserManager.AddToRole("ef05fa89-239b-460b-b33a-f45bd797f92a", "Admin");
            UserManager.AddToRole("bae907d1-71d5-4550-81ec-afab90202c60", "BandMember");
            UserManager.AddToRole("af57c5dd-082b-4cc2-a65d-670b4f6457d7", "BandMember");
            UserManager.AddToRole("b276f098-be7a-43f5-8861-6fe79c94bf79", "BandMember");
            UserManager.AddToRole("3de224ec-22e9-48d9-9f98-f29c143b39d7", "BandMember");
            UserManager.AddToRole("d9a3578c-0abd-4551-9762-15ccaa5a4240", "BandMember");
        }
    }
}
