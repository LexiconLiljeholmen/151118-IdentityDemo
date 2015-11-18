namespace IdentityDemo.Migrations {
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentityDemo.Models.ApplicationDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            ContextKey = "IdentityDemo.Models.ApplicationDbContext";
        }

        protected override void Seed(IdentityDemo.Models.ApplicationDbContext context) {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!roleManager.RoleExists("KeeperOfSecrets")) {
                var role = new IdentityRole { Name = "KeeperOfSecrets" };
                roleManager.Create(role);
            }

            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            
            foreach (string email in new[] { "adrian@lexicon.se", "admin@lexicon.se" }) {
                if (!context.Users.Any(u => u.UserName == email)) {              
                    var user = new ApplicationUser { UserName = email, Email = email };
                    manager.Create(user, "foobar");                
                }
            }

            var keeper = manager.FindByName("admin@lexicon.se");
            manager.AddToRole(keeper.Id, "KeeperOfSecrets");
        }
    }
}
