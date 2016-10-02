namespace ShipsService.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShipsService.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ShipsService.Models.ApplicationDbContext";
        }

        protected override void Seed(ShipsService.Models.ApplicationDbContext context)
        {
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            rm.Create(new IdentityRole("Administrator"));
            rm.Create(new IdentityRole("User"));

            /*
            var store = new UserStore<ApplicationUser>();
            ApplicationUserManager userManager = new ApplicationUserManager(store);

            var user = new ApplicationUser
            {
                UserName = "admin@sdo.com",
                Password = "test_admin",
                Email = "admin@sdo.com",
                RegistrationDate = DateTime.Now,
                UserInfo = "user",
                BlockDate = DateTime.Now,
                IsBlocked = true,
                BlockReason = ""
            };

            userManager.Create(user, user.Password);

            // Определим роль для первого пользователя по умолчанию            
            userManager.AddToRole(user.Id, "Administrator");

            var ship = new Ship();
            ship.Author = user;
            ship.AuthorId = user.Id;
            ship.Description = "Описание корабля";
            ship.Name = "Название";

            context.Ships.Add(ship);
            */
            context.SaveChanges();
            
        }
    }
}
