using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

using Restfulie.Server;
using Restfulie.Server.Results;

using AutoMapper;

using iTunesLibrary.Domain;

namespace iTunesLibrary.Web.Controllers
{
	[ActAsRestfulie]
	[HandleError]
	public class MusicaController : RestfulController<Musica>
	{
		public MusicaController()
		{
			Mapper.CreateMap<Musica, Models.Musica>();
			Mapper.CreateMap<Models.Musica, Musica>();

			Mapper.CreateMap<Musica, Musica>()
				.ForAllMembers(m => m.Condition(c => !c.IsSourceValueNull));
		}

		public MusicaController(IRepositorio<Musica> repositorio) : this()
		{
			this.repositorio = repositorio;
		}

		[HttpPost]
		public override ActionResult Inclui(Musica musica)
		{
			var nova = repositorio.Salva(musica);

			return new Created(Mapper.Map<Musica, Models.Musica>(nova));
		}

		[HttpPut]
		public override ActionResult Altera(Musica musica)
		{
			var alterada = repositorio.Carrega(musica.Id);

			if (alterada != null)
			{
				Mapper.Map<Musica, Musica>(musica, alterada);

				return new OK(Mapper.Map<Musica, Models.Musica>(alterada));
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

			return new OK(Mapper.Map<Musica, Models.Musica>(excluida));
		}

		[HttpGet]
		public override ActionResult Lista()
		{
			var listaModels = new List<Models.Musica>();

			foreach (var musica in repositorio.Lista())
				listaModels.Add(Mapper.Map<Musica, Models.Musica>(musica));

			return new OK(listaModels);
		}

		[HttpGet]
		public override ActionResult Exibe(int id)
		{
			var musicaRecuperada = repositorio.Carrega(id);

			if (musicaRecuperada != null)
				return new OK(Mapper.Map<Musica, Models.Musica>(musicaRecuperada));
			else
				return new NotFound();
		}
	}
}
