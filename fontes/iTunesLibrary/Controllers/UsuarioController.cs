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
		public UsuarioController()
		{
			Mapper.CreateMap<Usuario, Models.Usuario>();
			Mapper.CreateMap<Models.Usuario, Usuario>();

			Mapper.CreateMap<Usuario, Usuario>()
				.ForAllMembers(m => m.Condition(c => !c.IsSourceValueNull));
		}

		public UsuarioController(IRepositorio<Usuario> repositorio) : this()
		{
			this.repositorio = repositorio;
		}

		[HttpPost]
		public override ActionResult Inclui(Usuario usuario)
		{
			var nova = repositorio.Salva(usuario);

			return new Created(Mapper.Map<Usuario, Models.Usuario>(nova));
		}

		[HttpPut]
		public override ActionResult Altera(Usuario usuario)
		{
			var alterada = repositorio.Carrega(usuario.Id);

			if (alterada != null)
			{
				Mapper.Map<Usuario, Usuario>(usuario, alterada);

				return new OK(Mapper.Map<Usuario, Models.Usuario>(alterada));
			}
			else
			{
				return new NotFound();
			}
		}

		[HttpDelete]
		public override ActionResult Exclui(int id)
		{
			var excluida = repositorio.Exclui(id);

			if (excluida != null)
				return new OK(Mapper.Map<Usuario, Models.Usuario>(excluida));
			else
				return new NotFound();
		}

		[HttpGet]
		public override ActionResult Lista()
		{
			var listaModels = new List<Models.Usuario>();

			foreach (var usuario in repositorio.Lista())
				listaModels.Add(Mapper.Map<Usuario, Models.Usuario>(usuario));

			return new OK(listaModels);
		}

		[HttpGet]
		public override ActionResult Exibe(int id)
		{
			var usuarioRecuperada = repositorio.Carrega(id);

			if (usuarioRecuperada != null)
				return new OK(Mapper.Map<Usuario, Models.Usuario>(usuarioRecuperada));
			else
				return new NotFound();
		}
	}
}