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
				"Individual resource action",
				"{controller}/{id}/{action}",
				new { action = "Inicio" },
				new
				{
					httpMethod = new HttpMethodConstraint("GET"), // only allow GET for custom actions
					id = @"\d+" // id must be numeric
				}
			);

			routes.MapRoute(
				"Individual resource",
				"{controller}/{id}",
				new { action = "Inicio" },
				new { id = @"\d+" } // id must be numeric
			);

			routes.MapRoute(
				"Resource collection action",
				"{controller}/{action}",
				new { action = "Inicio" },
				new { httpMethod = new HttpMethodConstraint("GET") } // only allow GET for custom actions
			);

			routes.MapRoute(
				"Resource collection",
				"{controller}",
				new { action = "Inicio" }
			);

			routes.MapRoute(
				"Default",
				"",
				new { controller = "Musica", action = "Inicio" },
				new { httpMethod = new HttpMethodConstraint("GET") }  // only allow GET for default
			);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			ControllerBuilder.Current.SetControllerFactory(new RESTfulControllerFactory());
			ModelBinders.Binders.DefaultBinder = new ExtjsModelBinder();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}
	}
}