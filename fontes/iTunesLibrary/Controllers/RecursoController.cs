using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Restfulie.Server.Results;

namespace iTunesLibrary.Web.Controllers
{
    public abstract class RecursoController<Recurso> : Controller
    {
		public virtual ActionResult Inicio()
        {
            return new OK();
        }

		public virtual ActionResult Lista()
		{
			return new OK();
		}

		public virtual ActionResult Exibe()
		{
			return new OK();
		}

		public virtual ActionResult Novo()
		{
			return new OK();
		}

		public virtual ActionResult Cria()
		{
			return new Created();
		}

		public virtual ActionResult Altera()
		{
			return new OK();
		}

		public virtual ActionResult Exclui()
		{
			return new OK();
		}
    }
}
