using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace iTunesLibrary.Web.Mvc
{
	public class RESTfulControllerFactory : DefaultControllerFactory
    {
        private readonly RestfulActionInvoker actionInvoker;

        public RESTfulControllerFactory()
        {
            actionInvoker = new RestfulActionInvoker();
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controller = base.CreateController(requestContext, controllerName) as Controller;
            controller.ActionInvoker = actionInvoker;

            return controller;
        }

        private class RestfulActionInvoker : ControllerActionInvoker
        {
            public override bool InvokeAction(ControllerContext controllerContext, string actionName)
            {
                var request = controllerContext.HttpContext.Request;
                var httpVerb = request.HttpMethod.ToUpper();
                var routeData = controllerContext.RouteData.Values;

                // apply post overload where required
                if (httpVerb == "POST" && request.Form.AllKeys.Contains("_verb"))
                {
                    httpVerb = request.Form["_verb"].ToUpper();
                }
                
                if (actionName.ToUpper() == "INICIO") // default action
                {
                    actionName = ActionNameFromVerb(httpVerb, RouteContainsId(routeData));
					controllerContext.RouteData.Values[ "action" ] = actionName;
                }

                return base.InvokeAction(controllerContext, actionName);
            }

            private static string ActionNameFromVerb(string httpVerb, bool idProvided)
            {
                switch (httpVerb)
                {
                    case "POST":
                        return "Inclui";
                    case "PUT":
                        return "Altera";
                    case "DELETE":
                        return "Exclui";
                    case "GET":
                        if (idProvided) return "Exibe";
                        return "Lista";
                }

                throw new ArgumentException(httpVerb + " cannot be handled");
            }

            private static bool RouteContainsId(RouteValueDictionary routeData)
            {
                return routeData.ContainsKey("id")
                       && routeData["id"] != null
                       && !string.IsNullOrEmpty(routeData["id"].ToString());
            }
        }
    }
}