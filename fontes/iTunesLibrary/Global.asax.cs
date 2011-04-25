using System.Web.Mvc;
using System.Web.Routing;

using Castle.Windsor;
using Castle.Windsor.Installer;

using iTunesLibrary.Web.Windsor;
using iTunesLibrary.Infra.Persistencia.Windsor;

namespace iTunesLibrary
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		private static WindsorContainer container;

		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("favicon.ico");
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Lista",
				"{controller}/",
				new { controller = "Musica", action = "Lista" },
				new
				{
					httpMethod = new HttpMethodConstraint("GET")
				}
			);

			routes.MapRoute(
				"Exibe",
				"{controller}/{id}",
				new { action = "Exibe" },
				new
				{
					id = @"\d+",
					httpMethod = new HttpMethodConstraint("GET")
				}
			);

			routes.MapRoute(
				"Inclui",
				"{controller}/",
				new { action = "Inclui" },
				new
				{
					httpMethod = new HttpMethodConstraint("POST")
				}
			);

			routes.MapRoute(
				"Exclui",
				"{controller}/{id}",
				new { action = "Exclui" },
				new
				{
					id = @"\d+",
					httpMethod = new HttpMethodConstraint("DELETE")
				}
			);

			routes.MapRoute(
				"Altera",
				"{controller}/{id}",
				new { action = "Altera" },
				new
				{
					id = @"\d+",
					httpMethod = new HttpMethodConstraint("PUT")
				}
			);

			routes.MapRoute(
				"Pesquisa", // Route name
				"{controller}/{indiceInicial},{quantidade},{ordem}", // URL with parameters
				new
				{ 
					controller = "Musica",
					action = "Pesquisa",
					indiceInicial = 0,
					quantidade = 10,
					ordem = UrlParameter.Optional
				} // Parameter defaults
			);

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Musica", action = "Lista", id = UrlParameter.Optional } // Parameter defaults
			);
		}

		private static void BootstrapContainer()
		{
			container = new WindsorContainer();
			container.Install(
				new WindsorRepositoriosInstaller(),
				new WindsorControllersInstaller()
			);

			var controllerFactory = new WindsorControllerFactory(container.Kernel);
			ControllerBuilder.Current.SetControllerFactory(controllerFactory);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);

			BootstrapContainer();
		}

		protected void Application_End()
		{
			container.Dispose();
		}
	}
}