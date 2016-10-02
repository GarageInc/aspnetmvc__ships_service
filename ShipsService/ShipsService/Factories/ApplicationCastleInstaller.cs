using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ShipsService.Models;
using ShipsService.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShipsService.Factories
{
    public class ApplicationCastleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // регистрируем компоненты приложения
            container.Register(Component.For<IRepository>().ImplementedBy<AppRepository>());

            container.Resolve<IRepository>().Context = new ApplicationDbContext();
            
            // регистрируем каждый контроллер по отдельности
            var controllers = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes().Where(x => x.BaseType == typeof(Controller)).ToList();

            foreach (var controller in controllers)
            {
                container.Register(Component.For(controller).LifestyleTransient());
            }
        }
    }
}