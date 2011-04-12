using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iTunesLibrary.Controllers
{
    public abstract class RecursoController<Recurso> : Controller
    {
		public virtual ActionResult Inicio()
        {
            return View();
        }

		public virtual ActionResult Lista()
		{
			return View();
		}

		public virtual ActionResult Exibe()
		{
			return View();
		}

		public virtual ActionResult Novo()
		{
			return View();
		}

		public virtual ActionResult Cria()
		{
			return View();
		}

		public virtual ActionResult Altera()
		{
			return View();
		}

		public virtual ActionResult Exclui()
		{
			return View();
		}
    }
}
