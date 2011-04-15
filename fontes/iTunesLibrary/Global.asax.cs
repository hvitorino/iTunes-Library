using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Restfulie.Server.Configuration;
using Restfulie.Server.MediaTypes;
using Restfulie.Server.Unmarshalling.Deserializers.Xml;
using Restfulie.Server.Marshalling.Serializers.XmlAndHypermedia;
using Restfulie.Server.Unmarshalling.Deserializers.Json;
using Restfulie.Server.Marshalling.Serializers.Json;

using iTunesLibrary.Web.Mvc;
using iTunesLibrary.Web.Comunicacao;

namespace iTunesLibrary
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
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
				new { action = "Lista" },
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
					id = @"\d+"
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
				"Default",
				"",
				new { controller = "Musica", action = "Inicio" },
				new { httpMethod = new HttpMethodConstraint("GET") }
			);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}
	}
}