using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using AutoMapper;
using AutoMapper.Mappers;

using Restfulie.Server;
using Restfulie.Server.Results;

using iTunesLibrary.Domain;

namespace iTunesLibrary.Web.Controllers
{
	[ActAsRestfulie]
	[HandleError]
	public class UsuarioController : RestfulController<Usuario>
	{
		private List<Usuario> usuarios = new List<Usuario>
		{
			new Usuario
			{
				Id = 1,
				Nome = "hvitorino"
			}
		};

		[HttpGet]
		public override ActionResult Lista()
		{
			var lista = new List<Models.Usuario>();

			usuarios.ForEach(
				usr =>
					lista.Add(new Models.Usuario
					{
						Id = usr.Id,
						Nome = usr.Nome
					})
			);

			return new OK(lista);
		}

		[HttpDelete]
		public override ActionResult Exclui(int id)
		{
			throw new System.NotImplementedException();
		}

		[HttpGet]
		public override ActionResult Exibe(int id)
		{
			var usuarioExibido = usuarios.Where(usr => usr.Id == id).SingleOrDefault();

			if (usuarioExibido != null)
			{
				var usuario = new Models.Usuario
				{
					Id = usuarioExibido.Id,
					Nome = usuarioExibido.Nome
				};

				return new OK(usuario);
			}
			else 
			{
				return new NotFound();
			}
		}

		public override ActionResult Inclui(Usuario recurso)
		{
			throw new System.NotImplementedException();
		}

		public override ActionResult Altera(Usuario recurso)
		{
			throw new System.NotImplementedException();
		}
	}
}