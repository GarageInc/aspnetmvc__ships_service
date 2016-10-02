using Castle.Windsor;
using ShipsService.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ShipsService
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // создаем контейнер
            var container = new WindsorContainer();
            // регистрируем компоненты с помощью объекта ApplicationCastleInstaller
            container.Install(new ApplicationCastleInstaller());

            // Вызываем свою фабрику контроллеров
            var castleControllerFactory = new CastleControllerFactory(container);

            // Добавляем фабрику контроллеров для обработки запросов
            ControllerBuilder.Current.SetControllerFactory(castleControllerFactory);


            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
