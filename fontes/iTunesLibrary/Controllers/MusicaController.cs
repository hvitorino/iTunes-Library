using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

using Restfulie.Server;
using Restfulie.Server.Results;

using iTunesLibrary.Domain;

namespace iTunesLibrary.Web.Controllers
{
	[ActAsRestfulie]
	[HandleError]
	public class MusicaController : RestfulController<Musica>
	{
		public MusicaController(IRepositorio<Musica> repositorio)
		{
			this.repositorio = repositorio;
		}

		[HttpPost]
		public override ActionResult Inclui(Musica musica)
		{
			var nova = repositorio.Salva(musica);

			return new Created(nova);
		}

		[HttpPut]
		public override ActionResult Altera(Musica musica)
		{
			var alterada = repositorio.Altera(musica);

			return new OK(alterada);
		}

		[HttpDelete]
		public override ActionResult Exclui(int id)
		{
			var excluida = repositorio.Exclui(id);

			return new OK(excluida);
		}

		[HttpGet]
		public override ActionResult Lista()
		{
			return new OK(repositorio.Lista());
		}

		[HttpGet]
		public override ActionResult Exibe(int id)
		{
			var musicaRecuperada = repositorio.Carrega(id);

			if (musicaRecuperada != null)
				return new OK(musicaRecuperada);
			else
				return new NotFound();
		}
	}
}
