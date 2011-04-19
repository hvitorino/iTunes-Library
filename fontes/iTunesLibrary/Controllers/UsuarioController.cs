using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using AutoMapper;
using AutoMapper.Mappers;

using Restfulie.Server;
using Restfulie.Server.Results;

using iTunesLibrary.Domain;
using iTunesLibrary.Web.Mapas;

namespace iTunesLibrary.Web.Controllers
{
	[ActAsRestfulie]
	[HandleError]
	public class UsuarioController : RestfulController<Usuario>
	{
		public UsuarioController()
		{ 
		}

		public UsuarioController(IRepositorio<Usuario> repositorio)
		{
			this.repositorio = repositorio;
		}

		[HttpPost]
		public override ActionResult Inclui(Usuario usuario)
		{
			var novo = repositorio.Salva(usuario);

			return new Created(novo.ConverteParaModel());
		}

		[HttpPut]
		public override ActionResult Altera(Usuario usuario)
		{
			var alterado = repositorio.Altera(usuario);

			return new OK(alterado.ConverteParaModel());
		}

		[HttpDelete]
		public override ActionResult Exclui(int id)
		{
			var excluida = repositorio.Exclui(id);

			return new OK(excluida.ConverteParaModel());
		}

		[HttpGet]
		public override ActionResult Lista()
		{
			return new OK(repositorio.Lista().ConverteParaModel());
		}

		[HttpGet]
		public override ActionResult Exibe(int id)
		{
			var usuarioRecuperado = repositorio.Carrega(id);

			if (usuarioRecuperado != null)
				return new OK(usuarioRecuperado.ConverteParaModel());
			else
				return new NotFound();
		}
	}
}