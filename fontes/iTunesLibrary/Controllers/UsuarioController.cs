using System;
using System.Collections.Generic;
using System.Web.Mvc;

using Restfulie.Server;
using Restfulie.Server.Results;

using iTunesLibrary.Domain;

namespace iTunesLibrary.Web.Controllers
{
	[ActAsRestfulie]
	[HandleError]
	public class UsuarioController : RecursoController<Usuario>
	{
		private Usuario usuario = new Usuario
		{
			Id = 1,
			Nome = "hvitorino"
		};

		//
		// GET: /login-usuario/musicas/

		public override ActionResult Inicio()
		{
			return new OK(new Models.Usuario
			{
				Id = usuario.Id,
				Nome = usuario.Nome
			});
		}
	}
}