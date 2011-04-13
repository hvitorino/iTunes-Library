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
	public class MusicaController : RecursoController<Musica>
	{
		private List<Musica> musicas = new List<Musica>
		{
			new Musica 
			{
				Id = 1,
				Nome = "Fire",
				Artista = "Jimi Hendrix"
			},
			new Musica 
			{
				Id = 2,
				Nome = "Hey Joe",
				Artista = "Jimi Hendrix"
			},
			new Musica 
			{
				Id = 3,
				Nome = "All Along The Watchtower",
				Artista = "Jimi Hendrix"
			},
			new Musica 
			{
				Id = 4,
				Nome = "Iron Maiden",
				Artista = "Iron Maiden"
			},
			new Musica 
			{
				Id = 5,
				Nome = "Hallowed Be Thy Name",
				Artista = "Iron Maiden"
			}
		};

		[HttpGet]
		public override ActionResult Inicio()
		{
			return new OK(musicas);
		}
	}
}
